using Microsoft.AspNetCore.Mvc;
using RentCars.Api.Models;
using RentCars.Api.Services.Interfaces;

namespace RentCars.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlquilerController : ControllerBase
    {
        private readonly IAlquilerService _alquilerService;
        public AlquilerController(IAlquilerService alquilerService)
        {
            _alquilerService = alquilerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlquileres()
        {
            var alquileres = await _alquilerService.GetAllAlquileresAsync();
            return Ok(alquileres);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlquiler(int id)
        {
            var alquiler = await _alquilerService.GetAlquilerByIdAsync(id);
            if (alquiler == null) return NotFound();
            return Ok(alquiler);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlquiler([FromBody] Alquiler alquiler)
        {
            var nuevo = await _alquilerService.CreateAlquilerAsync(alquiler);
            return CreatedAtAction(nameof(GetAlquiler), new { id = nuevo.Id }, nuevo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAlquiler(int id, [FromBody] Alquiler alquiler)
        {
            if (id != alquiler.Id) return BadRequest();
            var actualizado = await _alquilerService.UpdateAlquilerAsync(alquiler);
            return Ok(actualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlquiler(int id)
        {
            var eliminado = await _alquilerService.DeleteAlquilerAsync(id);
            if (!eliminado) return NotFound();
            return NoContent();
        }
    }

