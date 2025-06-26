
using Microsoft.AspNetCore.Mvc;
using RentCars.Api.DTOs.Empleado;
using RentCars.Api.Models;
using RentCars.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCars.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadosController : ControllerBase

    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadosController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadoResponse>>> GetAll()
        {
            var empleados = await _empleadoService.GetAllAsync();

            return Ok(empleados.Select(e => new EmpleadoResponse
            {
                EmpleadoId = e.EmpleadoId,
                Nombre_Completo = e.Nombre_Completo,
                Cargo = e.Cargo,
                DNI = e.DNI,
                Telefono = e.Telefono,
                Email = e.Email,
                Sucursal = e.Sucursal,
                FechaAlta = e.FechaAlta,
                Activo = e.Activo
            }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleadoResponse>> GetById(int id)
        {
            var empleado = await _empleadoService.GetByIdAsync(id);
            if (empleado == null) return NotFound();

            return Ok(new EmpleadoResponse
            {
                EmpleadoId = empleado.EmpleadoId,
                Nombre_Completo = empleado.Nombre_Completo,
                Cargo = empleado.Cargo,
                DNI = empleado.DNI,
                Telefono = empleado.Telefono,
                Email = empleado.Email,
                Sucursal = empleado.Sucursal,
                FechaAlta = empleado.FechaAlta,
                Activo = empleado.Activo
            });
        }

        [HttpPost]
        public async Task<ActionResult<EmpleadoResponse>> Create(EmpleadoCreateRequest dto)
        {
            var nuevo = new Empleado
            {
                Nombre_Completo = dto.Nombre_Completo,
                Cargo = dto.Cargo,
                DNI = dto.DNI,
                Telefono = dto.Telefono,
                Email = dto.Email,
                Sucursal = dto.Sucursal,
                FechaAlta = dto.FechaAlta,
                Activo = dto.Activo
            };

            var creado = await _empleadoService.CreateAsync(nuevo);

            return CreatedAtAction(nameof(GetById), new { id = creado.EmpleadoId }, new EmpleadoResponse
            {
                EmpleadoId = creado.EmpleadoId,
                Nombre_Completo = creado.Nombre_Completo,
                Cargo = creado.Cargo,
                DNI = creado.DNI,
                Telefono = creado.Telefono,
                Email = creado.Email,
                Sucursal = creado.Sucursal,
                FechaAlta = creado.FechaAlta,
                Activo = creado.Activo
            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmpleadoResponse>> Update(int id, EmpleadoUpdateRequest dto)
        {
            var update = new Empleado
            {
                Nombre_Completo = dto.Nombre_Completo,
                Cargo = dto.Cargo,
                DNI = dto.DNI,
                Telefono = dto.Telefono,
                Email = dto.Email,
                Sucursal = dto.Sucursal,
                Activo = dto.Activo
            };

            var actualizado = await _empleadoService.UpdateAsync(id, update);
            if (actualizado == null) return NotFound();

            return Ok(new EmpleadoResponse
            {
                EmpleadoId = actualizado.EmpleadoId,
                Nombre_Completo = actualizado.Nombre_Completo,
                Cargo = actualizado.Cargo,
                DNI = actualizado.DNI,
                Telefono = actualizado.Telefono,
                Email = actualizado.Email,
                Sucursal = actualizado.Sucursal,
                FechaAlta = actualizado.FechaAlta,
                Activo = actualizado.Activo
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _empleadoService.DeleteAsync(id);
            if (!eliminado) return NotFound();
            return NoContent();
        }
    }
}
