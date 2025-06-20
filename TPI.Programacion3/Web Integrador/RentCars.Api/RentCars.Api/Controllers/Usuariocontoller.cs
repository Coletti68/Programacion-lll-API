using Microsoft.AspNetCore.Mvc;
using RentCars.Api.Data;
using RentCars.Api.Models;

namespace RentCars.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetUsuarios()
        {
            var usuarios = _context.Usuarios.ToList();
            return Ok(usuarios);
        }
    }
}