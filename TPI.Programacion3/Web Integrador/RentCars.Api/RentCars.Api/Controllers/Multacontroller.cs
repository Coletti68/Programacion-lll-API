using Microsoft.AspNetCore.Mvc;
using RentCars.Api.DTOs.Multa;
using RentCars.Api.Services.Interfaces;

namespace RentCars.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MultasController : ControllerBase
    {
        private readonly IMultaService _service;

        public MultasController(IMultaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var multas = await _service.GetAllAsync();
            return Ok(multas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var multa = await _service.GetByIdAsync(id);
            if (multa == null) return NotFound();
            return Ok(multa);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MultaCreateRequest request)
        {
            var created = await _service.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = created.MultaId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MultaUpdateRequest request)
        {
            var updated = await _service.UpdateAsync(id, request);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
