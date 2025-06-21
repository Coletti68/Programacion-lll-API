using Microsoft.AspNetCore.Mvc;
using RentCars.Api.Models;
using RentCars.Api.Services.Interfaces;

namespace RentCars.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactoController : ControllerBase
    {
        private readonly IContactoService _contactoService;
        public ContactoController(IContactoService contactoService)
        {
            _contactoService = contactoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetContactos()
        {
            var contactos = await _contactoService.GetAllContactosAsync();
            return Ok(contactos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContacto(int id)
        {
            var contacto = await _contactoService.GetContactoByIdAsync(id);
            if (contacto == null) return NotFound();
            return Ok(contacto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContacto([FromBody] Contacto contacto)
        {
            var nuevo = await _contactoService.CreateContactoAsync(contacto);
            return CreatedAtAction(nameof(GetContacto), new { id = nuevo.Id }, nuevo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContacto(int id)
        {
            var eliminado = await _contactoService.DeleteContactoAsync(id);
            if (!eliminado) return NotFound();
            return NoContent();
        }
    }
}