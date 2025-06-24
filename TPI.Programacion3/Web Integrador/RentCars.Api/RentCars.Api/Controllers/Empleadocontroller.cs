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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
    {
        var empleados = await _empleadoService.GetAllAsync(); // <- aquí
        return Ok(empleados);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Empleado>> GetEmpleado(int id)
    {
        var empleado = await _empleadoService.GetByIdAsync(id); // <- aquí
        if (empleado == null)
            return NotFound();
        return Ok(empleado);
    }

    [HttpPost]
    public async Task<ActionResult<Empleado>> CreateEmpleado(Empleado empleado)
    {
        var creado = await _empleadoService.CreateAsync(empleado); // <- aquí
        return CreatedAtAction(nameof(GetEmpleado), new { id = creado.Id }, creado);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateEmpleado(int id, Empleado empleado)
    {
        if (id != empleado.Id)
            return BadRequest("ID no coincide.");

        var actualizado = await _empleadoService.UpdateAsync(empleado); // <- aquí
        if (actualizado == null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEmpleado(int id)
    {
        var eliminado = await _empleadoService.DeleteAsync(id); // <- aquí
        if (!eliminado)
            return NotFound();

        return NoContent();
    }

}
