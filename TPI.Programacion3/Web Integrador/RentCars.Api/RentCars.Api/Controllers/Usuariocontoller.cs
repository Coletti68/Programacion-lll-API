using Microsoft.AspNetCore.Mvc;
using RentCars.Api.DTOs.Usuario;
using RentCars.Api.Models;
using RentCars.Api.Services.Interfaces;

namespace RentCars.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: api/usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioResponseDTO>>> GetAll()
        {
            var usuarios = await _usuarioService.GetAllAsync();

            var response = usuarios.Select(u => new UsuarioResponseDTO
            {
                UsuarioId = u.UsuarioId,
                NombreCompleto = u.Nombre_Completo,
                TipoDocumento = u.TipoDocumento,
                DNI = u.DNI,
                FechaNacimiento = u.FechaNacimiento,
                Telefono = u.Telefono,
                Email = u.Email,
                Pais = u.Pais,
                Direccion = u.Direccion,
                FechaRegistro = u.FechaRegistro
            });

            return Ok(response);
        }

        //GET: api/usuario/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioResponseDTO>> GetById(int id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);
            if (usuario == null) return NotFound();

            var response = new UsuarioResponseDTO
            {
                UsuarioId = usuario.UsuarioId,
                NombreCompleto = usuario.Nombre_Completo,
                TipoDocumento = usuario.TipoDocumento,
                DNI = usuario.DNI,
                FechaNacimiento = usuario.FechaNacimiento,
                Telefono = usuario.Telefono,
                Email = usuario.Email,
                Pais = usuario.Pais,
                Direccion = usuario.Direccion,
                FechaRegistro = usuario.FechaRegistro
            };

            return Ok(response);
        }

        // POST: api/usuario
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuarioRegistroDTO dto)
        {
            var nuevo = new Usuario
            {
                Nombre_Completo = dto.NombreCompleto,
                password = dto.password,
                TipoDocumento = dto.TipoDocumento,
                DNI = dto.DNI,
                FechaNacimiento = DateTime.Parse(dto.FechaNacimiento).Date,
                Telefono = dto.Telefono,
                Email = dto.Email,
                Pais = dto.Pais,
                Direccion = dto.Direccion,
            };

            var creado = await _usuarioService.CreateAsync(nuevo);

            var response = new UsuarioResponseDTO
            {
                UsuarioId = creado.UsuarioId,
                NombreCompleto = creado.Nombre_Completo,
                TipoDocumento = creado.TipoDocumento,
                DNI = creado.DNI,
                FechaNacimiento = creado.FechaNacimiento,
                Telefono = creado.Telefono,
                Email = creado.Email,
                Pais = creado.Pais,
                Direccion = creado.Direccion,
            };

            return CreatedAtAction(nameof(GetById), new { id = creado.UsuarioId }, response);
        }

        // PUT: api/usuario
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioUpdateDTO dto)
        {
            var existente = await _usuarioService.GetByIdAsync(id);
            if (existente == null) return NotFound();

            // Solo actualizás los campos que vengan con valor
            if (!string.IsNullOrEmpty(dto.NombreCompleto))
                existente.Nombre_Completo = dto.NombreCompleto;

            if (!string.IsNullOrEmpty(dto.TipoDocumento))
                existente.TipoDocumento = dto.TipoDocumento;

            if (!string.IsNullOrEmpty(dto.DNI))
                existente.DNI = dto.DNI;

            if (!string.IsNullOrEmpty(dto.FechaNacimiento))
                existente.FechaNacimiento = DateTime.Parse(dto.FechaNacimiento).Date;

            if (!string.IsNullOrEmpty(dto.Telefono))
                existente.Telefono = dto.Telefono;

            if (!string.IsNullOrEmpty(dto.Email))
                existente.Email = dto.Email;

            if (!string.IsNullOrEmpty(dto.Pais))
                existente.Pais = dto.Pais;

            if (!string.IsNullOrEmpty(dto.Direccion))
                existente.Direccion = dto.Direccion;

            if (!string.IsNullOrEmpty(dto.password))
                existente.password = dto.password; // futuro lugar para hashear


            var actualizado = await _usuarioService.UpdateAsync(id, existente);
            return actualizado != null ? NoContent() : StatusCode(500, "No se pudo actualizar el usuario.");
        }


        // DELETE: api/usuario/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _usuarioService.DeleteAsync(id);
            return eliminado ? NoContent() : NotFound();
        }
    }
}
