using System.Collections.Generic;
using System.Threading.Tasks;
using RentCars.Api.Models;

public class AceptacionTerminosService : IAceptacionTerminosService
{
    private readonly ApplicationDbContext _context;

    public AceptacionTerminosController(IAceptacionTerminosService aceptacionService)
    {
        _aceptacionService = aceptacionService;
    }

    // GET: api/aceptacionterminos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AceptacionTerminos>>> GetAceptaciones()
    {
        var aceptaciones = await _aceptacionService.GetAllAsync();
        return Ok(aceptaciones);
    }

    // GET: api/aceptacionterminos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<AceptacionTerminos>> GetAceptacion(int id)
    {
        var aceptacion = await _aceptacionService.GetByIdAsync(id);
        if (aceptacion == null)
            return NotFound();

        return Ok(aceptacion);
    }

    // POST: api/aceptacionterminos
    [HttpPost]
    public async Task<ActionResult<AceptacionTerminos>> CreateAceptacion(AceptacionTerminos aceptacion)
    {
        var creada = await _aceptacionService.CreateAsync(aceptacion);
        return CreatedAtAction(nameof(GetAceptacion), new { id = creada.Id }, creada);
    }

    // PUT: api/aceptacionterminos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAceptacion(int id, AceptacionTerminos aceptacion)
    {
        if (id != aceptacion.Id)
            return BadRequest("El ID no coincide con el recurso a actualizar.");

        var actualizada = await _aceptacionService.UpdateAsync(aceptacion);
        if (actualizada == null)
            return NotFound();

        return NoContent();
    }

    // DELETE: api/aceptacionterminos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAceptacion(int id)
    {
        var eliminada = await _aceptacionService.DeleteAsync(id);
        if (!eliminada)
            return NotFound();

        return NoContent();
    }
}
