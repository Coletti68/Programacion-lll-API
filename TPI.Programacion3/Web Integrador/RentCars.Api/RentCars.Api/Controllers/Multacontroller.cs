using Microsoft.AspNetCore.Mvc;
using RentCars.Api.Models;
using RentCars.Api.Services.Interfaces;

namespace RentCars.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MultaController : ControllerBase
    {
        private readonly IMultaService _multaService;
        public MultaController(IMultaService multaService)
        {
            _multaService = multaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMultas()
        {
            var multas = await _multaService.GetAllMultasAsync();
            return Ok(multas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMulta(int id)
        {
            var multa = await _multaService.GetMultaByIdAsync(id);
            if (multa == null) return NotFound();
            return Ok(multa);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMulta([FromBody] Multa multa)
        {
            var nuevo = await _multaService.CreateMultaAsync(multa);
            return CreatedAtAction(nameof(GetMulta), new { id = nuevo.Id }, nuevo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMulta(int id, [FromBody] Multa multa)
        {
            if (id != multa.Id) return BadRequest();
            var actualizado = await _multaService.UpdateMultaAsync(multa);
            return Ok(actualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMulta(int id)
        {
            var eliminado = await _multaService.DeleteMultaAsync(id);
            if (!eliminado) return NotFound();
            return NoContent();
        }
    }
