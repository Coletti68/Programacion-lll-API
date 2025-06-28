using Microsoft.AspNetCore.Mvc;
using RentCars.Api.DTOs.Aceptacion;
using RentCars.Api.Models;
using RentCars.Api.Services.Interfaces;
using System.Linq;

namespace RentCars.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AceptacionTerminosController : ControllerBase
    {
        private readonly IAceptacionTerminosService _service;

        public AceptacionTerminosController(IAceptacionTerminosService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _service.GetAllAsync();

            var response = lista.Select(at => new AceptacionTerminosResponse
            {
                Id = at.Id,
                UsuarioId = at.UsuarioId,
                AlquilerId = at.AlquilerId,
                FechaAceptacion = at.FechaAceptacion,
                VersionTerminos = at.VersionTerminos
            });

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var at = await _service.GetByIdAsync(id);
            if (at == null) return NotFound();

            var response = new AceptacionTerminosResponse
            {
                Id = at.Id,
                UsuarioId = at.UsuarioId,
                AlquilerId = at.AlquilerId,
                FechaAceptacion = at.FechaAceptacion,
                VersionTerminos = at.VersionTerminos
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AceptacionTerminosRequest dto)
        {
            var nuevo = new AceptacionTerminos
            {
                UsuarioId = dto.UsuarioId,
                AlquilerId = dto.AlquilerId,
                VersionTerminos = dto.VersionTerminos,
                IP = dto.IP,
                FechaAceptacion = DateTime.Now
            };

            var creado = await _service.CreateAsync(nuevo);

            var response = new AceptacionTerminosResponse
            {
                Id = creado.Id,
                UsuarioId = creado.UsuarioId,
                AlquilerId = creado.AlquilerId,
                FechaAceptacion = creado.FechaAceptacion,
                VersionTerminos = creado.VersionTerminos
            };

            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AceptacionTerminosRequest dto)
        {
            var actualizado = new AceptacionTerminos
            {
                UsuarioId = dto.UsuarioId,
                AlquilerId = dto.AlquilerId,
                VersionTerminos = dto.VersionTerminos,
                IP = dto.IP,
                FechaAceptacion = DateTime.Now // Podés elegir mantener la original si preferís
            };

            var actualizadoDb = await _service.UpdateAsync(id, actualizado);
            if (actualizadoDb == null) return NotFound();

            var response = new AceptacionTerminosResponse
            {
                Id = actualizadoDb.Id,
                UsuarioId = actualizadoDb.UsuarioId,
                AlquilerId = actualizadoDb.AlquilerId,
                FechaAceptacion = actualizadoDb.FechaAceptacion,
                VersionTerminos = actualizadoDb.VersionTerminos
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _service.DeleteAsync(id);
            return eliminado ? NoContent() : NotFound();
        }
    }
}