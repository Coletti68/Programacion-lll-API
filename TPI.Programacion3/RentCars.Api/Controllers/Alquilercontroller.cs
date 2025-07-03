using Microsoft.AspNetCore.Mvc;
using RentCars.Api.DTOs.Alquiler;
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
        public async Task<IActionResult> Create([FromBody] AlquilerRegistroDTO dto)
        {
            if (!dto.AceptoTerminos)
            {
                return BadRequest("Debe aceptar los t�rminos y condiciones para realizar un alquiler.");
            }

            var alquiler = new Alquiler
            {
                UsuarioId = dto.UsuarioId,
                VehiculoId = dto.VehiculoId,
                EmpleadoId = dto.EmpleadoId,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                FechaDevolucion = dto.FechaDevolucion,
                Total = dto.Total,
                Estado = dto.Estado,
                Pagos = new List<Pago>(),
                Multas = new List<Multa>(),
                AceptoTerminos = dto.AceptoTerminos
            };

            var creado = await _alquilerService.CreateAsync(alquiler);
            return CreatedAtAction(nameof(GetById), new { id = creado.AlquilerId }, creado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AlquilerUpdate dto)
        {
            var actualizado = await _alquilerService.UpdateAsync(id, dto);
            return actualizado ? NoContent() : NotFound();
        }

        // DELETE: api/Alquiler/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _alquilerService.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }

        // GET: api/Alquiler/cliente/{clienteId}
        [HttpGet("usuario/{id}")]
        public async Task<IActionResult> GetByClienteId(int id)
        {
            var result = await _alquilerService.GetByUsuarioIdAsync(id);
            return Ok(result);
        }

        // GET: api/Alquiler/estado/{estado}
        [HttpGet("estado/{estado}")]
        public async Task<IActionResult> GetByEstado(string estado)
        {
            var estadosValidos = new[] { "Activo", "Cancelado", "Finalizado" };
            if (!estadosValidos.Contains(estado))
                return BadRequest("Estado inv�lido. Los valores permitidos son: Activo, Cancelado, Finalizado.");

            var result = await _alquilerService.GetByEstadoAsync(estado);
            return Ok(result);
        }

        // GET: api/Alquiler/rango?desde=2025-01-01&hasta=2025-12-31
        [HttpGet("rango")]
        public async Task<IActionResult> GetByRangoFechas(DateTime desde, DateTime hasta)
        {

            if (hasta < desde)
                return BadRequest("La fecha 'hasta' debe ser mayor o igual a la fecha 'desde'.");

            var result = await _alquilerService.GetByRangoFechasAsync(desde, hasta);
            return Ok(result);
        }

        // GET: api/Alquiler/activos
        [HttpGet("activos")]
        public async Task<IActionResult> GetActivos([FromQuery] int? id)
        {
            var alquileres = await _alquilerService.GetAlquileresActivosAsync(id);
            return Ok(alquileres);
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
            if (fechaDevolucion == default)
                return BadRequest("Se requiere una fecha de devoluci�n v�lida.");

            var result = await _alquilerService.FinalizarAlquilerAsync(id, fechaDevolucion);
            return result ? Ok() : NotFound();
        }

        // PUT: api/Alquiler/cancelar/{id}
        [HttpPut("cancelar/{id}")]
        public async Task<IActionResult> Cancelar(int id)
        { 
            var result = await _alquilerService.CancelarAlquilerAsync(id);
            if (!result)
                return BadRequest("No se puede cancelar el alquiler. Puede que ya est� finalizado o cancelado.");

            return Ok();
        }

        // GET: api/Alquiler/disponible?vehiculoId=1&desde=2025-07-01&hasta=2025-07-05
        [HttpGet("disponible")]
        public async Task<IActionResult> VerificarDisponibilidad(int vehiculoId, DateTime desde, DateTime hasta)
        {
            if (desde > hasta)
                return BadRequest("La fecha 'desde' debe ser anterior o igual a la fecha 'hasta'.");

            var disponible = await _alquilerService.VerificarDisponibilidadVehiculoAsync(vehiculoId, desde, hasta);
            return Ok(disponible);
        }

        // GET: api/Alquiler/vehiculo/5
        [HttpGet("vehiculo/{vehiculoId}")]
        public async Task<IActionResult> GetPorVehiculo(int vehiculoId)
        {
            var result = await _alquilerService.GetAlquileresPorVehiculoAsync(vehiculoId);

            if (result == null || !result.Any())
                return NotFound($"No se encontraron alquileres para el veh�culo con ID {vehiculoId}.");
            return Ok(result);
        }

        // GET: api/Alquiler/cliente/5/total
        [HttpGet("usuario/{id}/total")]
        public async Task<IActionResult> ContarPorUsuario(int id)
        {
            var count = await _alquilerService.ContarAlquileresPorUsuarioAsync(id);
            return Ok(count);
        }

        // GET: api/Alquiler/facturado?desde=2025-01-01&hasta=2025-12-31
        [HttpGet("facturado")]
        public async Task<IActionResult> CalcularTotal(DateTime desde, DateTime hasta)
        {
            if (hasta < desde)
                return BadRequest("La fecha 'hasta' debe ser mayor o igual a la fecha 'desde'.");
            var total = await _alquilerService.CalcularTotalFacturadoAsync(desde, hasta);
            return Ok(total);
        }
    }
}

