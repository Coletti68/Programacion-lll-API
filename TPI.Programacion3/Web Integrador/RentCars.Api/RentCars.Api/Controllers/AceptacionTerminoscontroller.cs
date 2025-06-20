using Microsoft.AspNetCore.Mvc;
using RentCars.Api.Models;
using RentCars.Api.Services.Interfaces;

namespace RentCars.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AceptacionTerminosController : ControllerBase
    {
        private readonly IAceptacionTerminosService _aceptacionService;
        public AceptacionTerminosController(IAceptacionTerminosService aceptacionService)
        {
            _aceptacionService = aceptacionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAceptaciones()
        {
            var aceptaciones = await _aceptacionService.GetAllAceptacionesAsync();
            return Ok(aceptaciones);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAceptacion([FromBody] AceptacionTerminos aceptacion)
        {
            var nuevo = await _aceptacionService.CreateAceptacionAsync(aceptacion);
            return CreatedAtAction(nameof(GetAceptaciones), new { id = nuevo.Id }, nuevo);
        }
    }
