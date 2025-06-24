using Microsoft.AspNetCore.Mvc;
using RentCars.Api.Models;
using RentCars.Api.Services;
using RentCars.Api.Services.Implementaciones;
using RentCars.Api.Services.Interfaces; // Ensure this namespace contains IAceptacionTerminosService

[ApiController] // Add this attribute to make it a valid controller
[Route("api/[controller]")]
public class AceptacionTerminosController : ControllerBase // Fix the missing class definition
{
    private readonly AceptacionTerminosService _aceptacionService;

    // Constructor
    public AceptacionTerminosController(IAceptacionTerminosService aceptacionService)
    {
        _aceptacionService = (AceptacionTerminosService?)aceptacionService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AceptacionTerminos>>> GetAceptaciones()
        => Ok(await _aceptacionService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<AceptacionTerminos>> GetAceptacion(int id)
    {
        var aceptacion = await _aceptacionService.GetByIdAsync(id);
        if (aceptacion == null) return NotFound();
        return Ok(aceptacion);
    }

    [HttpPost]
    public async Task<ActionResult<AceptacionTerminos>> CreateAceptacion(AceptacionTerminos aceptacion)
    {
        var creada = await _aceptacionService.CreateAsync(aceptacion);
        return CreatedAtAction(nameof(GetAceptacion), new { id = creada.Id }, creada);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAceptacion(int id, AceptacionTerminos aceptacion)
    {
        if (id != aceptacion.Id) return BadRequest("ID no coincide.");

        var existente = await _aceptacionService.GetByIdAsync(id);
        if (existente == null) return NotFound();

        // Simulamos actualización reutilizando el CreateAsync o implementando UpdateAsync más adelante.
        // Por ahora retornamos OK directamente o implementamos UpdateAsync en el servicio.

        // Si querés manejar Update, agregalo al servicio y lo implementamos.

        return Ok("Actualización simulada (no implementada aún)");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAceptacion(int id)
    {
        var eliminado = await _aceptacionService.DeleteAsync(id);
        if (!eliminado) return NotFound();
        return NoContent();
    }

}