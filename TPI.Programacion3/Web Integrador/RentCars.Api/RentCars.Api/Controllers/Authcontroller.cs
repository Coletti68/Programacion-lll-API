using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCars.Api.Data;
using RentCars.Api.DTOs.Auth;
using RentCars.Api.Models;
using RentCars.Api.Services.Interfaces;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RentCars.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ITokenService _tokenService;
        
        public AuthController(ApplicationDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("registro")]
        public async Task<IActionResult> Registrar(RegisterRequest dto)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Email == dto.Email))
                return BadRequest("El correo ya está registrado.");

            var usuario = new Usuario
            {
                Nombre_Completo = dto.NombreCompleto,
                Email = dto.Email,
                DNI = dto.DNI,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Rol = "Usuario",
                FechaRegistro = DateTime.Now
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok("Registro exitoso.");
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest dto)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(dto.Password, usuario.PasswordHash))
                return Unauthorized("Credenciales Incorrectas.");

            var token = _tokenService.GenerarToken(usuario);

            return Ok(new LoginResponse
            {
                Token = token,
                Expira = DateTime.Now.AddHours(2)
            });
        }


        [HttpPost("recuperar-password")]
        public async Task<IActionResult> SolicitarReset(ForgotPasswordRequest dto)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (usuario == null) return NotFound("Correo no registrado.");

            var token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            usuario.ResetToken = token;
            usuario.ResetTokenExpira = DateTime.UtcNow.AddHours(1);
            await _context.SaveChangesAsync();

            var link = $"{Request.Scheme}://{Request.Host}/reset-password?email={usuario.Email}&token={Uri.EscapeDataString(token)}";

            return Ok(new { mensaje = "Token generado", link });
        }

        [HttpPost("resetear-password")]
        public async Task<IActionResult> Resetear(ResetPasswordRequest dto)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u =>
                u.Email == dto.Email &&
                u.ResetToken == dto.Token &&
                u.ResetTokenExpira > DateTime.UtcNow);

            if (usuario == null)
                return BadRequest("Token inválido o expirado.");

            usuario.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.NuevaPassword);
            usuario.ResetToken = null;
            usuario.ResetTokenExpira = null;
            await _context.SaveChangesAsync();

            return Ok("Contraseña actualizada exitosamente.");
        }



        [HttpGet("actual")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null) return NotFound();
            return Ok(new
            {
                user.UsuarioId,
                user.Nombre_Completo,
                user.Email,
                user.Rol
            });
        }

    }
