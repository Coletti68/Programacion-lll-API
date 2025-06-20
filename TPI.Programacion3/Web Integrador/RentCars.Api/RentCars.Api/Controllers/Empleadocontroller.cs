using Microsoft.AspNetCore.Mvc;
using RentCars.Api.Models;
using RentCars.Api.Services.Interfaces;

namespace RentCars.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmpleados()
        {
            var empleados = await _empleadoService.GetAllEmpleadosAsync();
            return Ok(empleados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpleado(int id)
        {
            var empleado = await _empleadoService.GetEmpleadoByIdAsync(id);
            if (empleado == null) return NotFound();
            return Ok(empleado);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmpleado([FromBody] Empleado empleado)
        {
            var nuevo = await _empleadoService.CreateEmpleadoAsync(empleado);
            return CreatedAtAction(nameof(GetEmpleado), new { id = nuevo.Id }, nuevo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmpleado(int id, [FromBody] Empleado empleado)
        {
            if (id != empleado.Id) return BadRequest();
            var actualizado = await _empleadoService.UpdateEmpleadoAsync(empleado);
            return Ok(actualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var eliminado = await _empleadoService.DeleteEmpleadoAsync(id);
            if (!eliminado) return NotFound();
            return NoContent();
        }
    }
