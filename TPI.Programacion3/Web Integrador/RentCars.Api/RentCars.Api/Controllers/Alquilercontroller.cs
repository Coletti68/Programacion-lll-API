using Microsoft.AspNetCore.Mvc;
using RentCars.Api.Models;
using RentCars.Api.Services.Interfaces;

namespace RentCars.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlquilerController : ControllerBase
    {
        private readonly IAlquilerService _alquilerService;

        public AlquilerController(IAlquilerService alquilerService)
        {
            _alquilerService = alquilerService;
        }

        // GET: api/Alquiler
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var alquileres = await _alquilerService.GetAllAsync();
            return Ok(alquileres);
        }

        // GET: api/Alquiler/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var alquiler = await _alquilerService.GetByIdAsync(id);
            return alquiler == null ? NotFound() : Ok(alquiler);
        }

        // POST: api/Alquiler
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Alquiler alquiler)
        {
            var creado = await _alquilerService.CreateAsync(alquiler);
            return CreatedAtAction(nameof(GetById), new { id = creado.AlquilerId }, creado);
        }

        // PUT: api/Alquiler/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Alquiler alquiler)
        {
            var result = await _alquilerService.UpdateAsync(id, alquiler);
            return result ? NoContent() : NotFound();
        }

        // DELETE: api/Alquiler/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _alquilerService.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }

        // GET: api/Alquiler/cliente/{clienteId}
        [HttpGet("cliente/{clienteId}")]
        public async Task<IActionResult> GetByClienteId(int clienteId)
        {
            var result = await _alquilerService.GetByClienteIdAsync(clienteId);
            return Ok(result);
        }

        // GET: api/Alquiler/estado/{estado}
        [HttpGet("estado/{estado}")]
        public async Task<IActionResult> GetByEstado(string estado)
        {
            var result = await _alquilerService.GetByEstadoAsync(estado);
            return Ok(result);
        }

        // GET: api/Alquiler/rango?desde=2025-01-01&hasta=2025-12-31
        [HttpGet("rango")]
        public async Task<IActionResult> GetByRangoFechas(DateTime desde, DateTime hasta)
        {
            var result = await _alquilerService.GetByRangoFechasAsync(desde, hasta);
            return Ok(result);
        }

        // GET: api/Alquiler/activos
        [HttpGet("activos")]
        public async Task<IActionResult> GetActivos()
        {
            var result = await _alquilerService.GetAlquileresActivosAsync();
            return Ok(result);
        }

        // GET: api/Alquiler/vencidos
        [HttpGet("vencidos")]
        public async Task<IActionResult> GetVencidos()
        {
            var result = await _alquilerService.GetAlquileresVencidosAsync();
            return Ok(result);
        }

        // PUT: api/Alquiler/finalizar/{id}
        [HttpPut("finalizar/{id}")]
        public async Task<IActionResult> Finalizar(int id, [FromQuery] DateTime fechaDevolucion)
        {
            var result = await _alquilerService.FinalizarAlquilerAsync(id, fechaDevolucion);
            return result ? Ok() : NotFound();
        }

        // PUT: api/Alquiler/cancelar/{id}
        [HttpPut("cancelar/{id}")]
        public async Task<IActionResult> Cancelar(int id)
        {
            var result = await _alquilerService.CancelarAlquilerAsync(id);
            return result ? Ok() : NotFound();
        }

        // POST: api/Alquiler/{id}/multa
        [HttpPost("{id}/multa")]
        public async Task<IActionResult> RegistrarMulta(int id, [FromBody] Multa multa)
        {
            var result = await _alquilerService.RegistrarMultaAsync(id, multa);
            return result ? Ok() : NotFound();
        }

        // POST: api/Alquiler/{id}/pago
        [HttpPost("{id}/pago")]
        public async Task<IActionResult> AgregarPago(int id, [FromBody] Pago pago)
        {
            var result = await _alquilerService.AgregarPagoAsync(id, pago);
            return result ? Ok() : NotFound();
        }

        // GET: api/Alquiler/disponible?vehiculoId=1&desde=2025-07-01&hasta=2025-07-05
        [HttpGet("disponible")]
        public async Task<IActionResult> VerificarDisponibilidad(int vehiculoId, DateTime desde, DateTime hasta)
        {
            var disponible = await _alquilerService.VerificarDisponibilidadVehiculoAsync(vehiculoId, desde, hasta);
            return Ok(disponible);
        }

        // GET: api/Alquiler/vehiculo/5
        [HttpGet("vehiculo/{vehiculoId}")]
        public async Task<IActionResult> GetPorVehiculo(int vehiculoId)
        {
            var result = await _alquilerService.GetAlquileresPorVehiculoAsync(vehiculoId);
            return Ok(result);
        }

        // GET: api/Alquiler/cliente/5/total
        [HttpGet("cliente/{clienteId}/total")]
        public async Task<IActionResult> ContarPorCliente(int clienteId)
        {
            var count = await _alquilerService.ContarAlquileresPorClienteAsync(clienteId);
            return Ok(count);
        }

        // GET: api/Alquiler/facturado?desde=2025-01-01&hasta=2025-12-31
        [HttpGet("facturado")]
        public async Task<IActionResult> CalcularTotal(DateTime desde, DateTime hasta)
        {
            var total = await _alquilerService.CalcularTotalFacturadoAsync(desde, hasta);
            return Ok(total);
        }
    }
}

