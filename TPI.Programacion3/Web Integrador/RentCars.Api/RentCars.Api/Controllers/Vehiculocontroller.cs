using Microsoft.AspNetCore.Mvc;
using RentCars.Api.Models;
using RentCars.Api.Services.Interfaces;

namespace RentCars.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculosController : ControllerBase
    {
        private readonly IVehiculoService _vehiculoService;

        public VehiculosController(IVehiculoService vehiculoService)
        {
            _vehiculoService = vehiculoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetVehiculos()
        {
            var vehiculos = await _vehiculoService.GetAllVehiculosAsync();
            return Ok(vehiculos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehiculo(int id)
        {
            var vehiculo = await _vehiculoService.GetVehiculoByIdAsync(id);
            if (vehiculo == null) return NotFound();
            return Ok(vehiculo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehiculo([FromBody] Vehiculo vehiculo)
        {
            var nuevo = await _vehiculoService.CreateVehiculoAsync(vehiculo);
            return CreatedAtAction(nameof(GetVehiculo), new { id = nuevo.Id }, nuevo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehiculo(int id, [FromBody] Vehiculo vehiculo)
        {
            if (id != vehiculo.Id) return BadRequest();
            var actualizado = await _vehiculoService.UpdateVehiculoAsync(vehiculo);
            return Ok(actualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculo(int id)
        {
            var eliminado = await _vehiculoService.DeleteVehiculoAsync(id);
            if (!eliminado) return NotFound();
            return NoContent();
        }
    }
}
