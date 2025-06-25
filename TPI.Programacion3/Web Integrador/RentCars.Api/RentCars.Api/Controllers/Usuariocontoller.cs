using Microsoft.AspNetCore.Mvc;
//using RentCars.Api.DTOs;
using RentCars.Api.Models;
using RentCars.Api.Services.Implementaciones;
using RentCars.Api.Services.Interfaces;


[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var usuarios = await _usuarioService.GetAllAsync();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var usuario = await _usuarioService.GetByIdAsync(id);
        if (usuario == null) return NotFound();

        return Ok(usuario);
    }

    /*[HttpPost]
    public async Task<IActionResult> Create([FromBody] UsuarioRegistroDTO dto)
    {
        var nuevo = new Usuario
        {
            Nombre_Completo = dto.NombreCompleto,
            Email = dto.Email,
            Telefono = dto.Telefono,
            DNI = dto.Dni,
            Direccion = dto.Direccion,
            Pais = dto.Pais,
            TipoDocumento = dto.TipoDocumento,
            password = dto.Password
        };

        var creado = await _usuarioService.CreateAsync(nuevo);
        return CreatedAtAction(nameof(GetById), new { id = creado.UsuarioId }, creado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var resultado = await _usuarioService.DeleteAsync(id);
        return resultado ? NoContent() : NotFound();
    }
}
    */
}

