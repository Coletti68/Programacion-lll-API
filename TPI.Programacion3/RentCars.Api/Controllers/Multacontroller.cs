using Microsoft.AspNetCore.Mvc;
using RentCars.Api.DTOs.Multa;
using RentCars.Api.Services.Interfaces;

namespace RentCars.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MultasController : ControllerBase
    {
        private readonly IMultaService _multaService;

        public MultasController(IMultaService multaservice)
        {
            _multaService = multaservice;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var multas = await _multaService.GetAllAsync();
            return Ok(multas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var multa = await _multaService.GetByIdAsync(id);
            if (multa == null) return NotFound();
            return Ok(multa);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MultaCreateRequest request)
        {
            var created = await _multaService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = created.MultaId }, created);
        }

        [HttpPatch("{id}/estado")]
        public async Task<IActionResult> CambiarEstado(int id, [FromBody] string nuevoEstado)
        {
            var result = await _multaService.CambiarEstadoAsync(id, nuevoEstado);
            return result ? NoContent() : NotFound("No se encontr� la multa especificada.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _multaService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }

        [HttpGet("impagas")]
        public async Task<IActionResult> ObtenerMultasImpagas()
        {
            var multas = await _multaService.ObtenerMultasImpagasAsync();
            return multas.Any() ? Ok(multas) : NotFound("No hay multas impagas registradas.");
        }
    }
}
