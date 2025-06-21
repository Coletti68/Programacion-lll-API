using Microsoft.AspNetCore.Mvc;
using RentCars.Api.Models;
using RentCars.Api.Services.Implementaciones;
using RentCars.Api.Services.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class EmpleadoController : ControllerBase
{
    private readonly IEmpleadoService _empleadoService;

    public EmpleadoController(IEmpleadoService empleadoService)
    {
        _empleadoService = empleadoService;
    }

    // GET: api/empleado
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
    {
        var empleados = await _empleadoService.GetAllEmpleadosAsync(); // Updated method name
        return Ok(empleados);
    }

    // GET: api/empleado/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Empleado>> GetEmpleado(int id)
    {
        var empleado = await _empleadoService.GetEmpleadoByIdAsync(id); // Updated method name
        if (empleado == null)
            return NotFound();
        return Ok(empleado);
    }

    // POST: api/empleado
    [HttpPost]
    public async Task<ActionResult<Empleado>> CreateEmpleado(Empleado empleado)
    {
        var creado = await _empleadoService.CreateEmpleadoAsync(empleado); // Updated method name
        return CreatedAtAction(nameof(GetEmpleado), new { id = creado.Id }, creado);
    }

    // PUT: api/empleado/5
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateEmpleado(int id, Empleado empleado)
    {
        if (id != empleado.Id)
            return BadRequest("ID no coincide.");

        var actualizado = await _empleadoService.UpdateEmpleadoAsync(empleado); // Updated method name
        if (actualizado == null)
            return NotFound();

        return NoContent();
    }

    // DELETE: api/empleado/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEmpleado(int id)
    {
        var eliminado = await _empleadoService.DeleteEmpleadoAsync(id); // Updated method name
        if (!eliminado)
            return NotFound();

        return NoContent();
    }
}
