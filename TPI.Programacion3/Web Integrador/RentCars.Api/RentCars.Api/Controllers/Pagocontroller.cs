using Microsoft.AspNetCore.Mvc;
using RentCars.Api.Models;
using RentCars.Api.Services.Interfaces;

namespace RentCars.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagoController : ControllerBase
    {
        private readonly IPagoService _pagoService;
        public PagoController(IPagoService pagoService)
        {
            _pagoService = pagoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPagos()
        {
            var pagos = await _pagoService.GetAllPagosAsync();
            return Ok(pagos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPago(int id)
        {
            var pago = await _pagoService.GetPagoByIdAsync(id);
            if (pago == null) return NotFound();
            return Ok(pago);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePago([FromBody] Pago pago)
        {
            var nuevo = await _pagoService.CreatePagoAsync(pago);
            return CreatedAtAction(nameof(GetPago), new { id = nuevo.Id }, nuevo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePago(int id, [FromBody] Pago pago)
        {
            if (id != pago.Id) return BadRequest();
            var actualizado = await _pagoService.UpdatePagoAsync(pago);
            return Ok(actualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePago(int id)
        {
            var eliminado = await _pagoService.DeletePagoAsync(id);
            if (!eliminado) return NotFound();
            return NoContent();
        }
    }
