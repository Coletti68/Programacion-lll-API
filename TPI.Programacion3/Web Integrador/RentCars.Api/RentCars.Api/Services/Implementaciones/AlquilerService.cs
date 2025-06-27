using System;
using RentCars.Api.Data;
using Microsoft.EntityFrameworkCore;
using RentCars.Api.Models;
using RentCars.Api.Services.Interfaces;

namespace RentCars.Api.Services.Implementaciones
{
    public class AlquilerService : IAlquilerService
    {
        private readonly ApplicationDbContext _context;

        public AlquilerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Alquiler>> GetAllAsync()
        {
            return await _context.Alquileres
                .Include(a => a.Cliente)
                .Include(a => a.Vehiculo)
                .Include(a => a.Empleado)
                .ToListAsync();
        }

        public async Task<Alquiler> GetByIdAsync(int id)
        {
            return await _context.Alquileres
                .Include(a => a.Cliente)
                .Include(a => a.Vehiculo)
                .Include(a => a.Empleado)
                .FirstOrDefaultAsync(a => a.AlquilerId == id);
        }

        public async Task<Alquiler> CreateAsync(Alquiler alquiler)
        {
            _context.Alquileres.Add(alquiler);
            await _context.SaveChangesAsync();
            return alquiler;
        }

        public async Task<bool> UpdateAsync(int id, Alquiler alquiler)
        {
            var existing = await _context.Alquileres.FindAsync(id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(alquiler);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var alquiler = await _context.Alquileres.FindAsync(id);
            if (alquiler == null) return false;

            _context.Alquileres.Remove(alquiler);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Alquiler>> GetByClienteIdAsync(int clienteId)
        {
            return await _context.Alquileres
                .Where(a => a.ClienteId == clienteId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Alquiler>> GetByEstadoAsync(string estado)
        {
            return await _context.Alquileres
                .Where(a => a.Estado == estado)
                .ToListAsync();
        }

        public async Task<IEnumerable<Alquiler>> GetByRangoFechasAsync(DateTime desde, DateTime hasta)
        {
            return await _context.Alquileres
                .Where(a => a.FechaInicio >= desde && a.FechaFin <= hasta)
                .ToListAsync();
        }

        public async Task<IEnumerable<Alquiler>> GetAlquileresActivosAsync()
        {
            return await _context.Alquileres
                .Where(a => a.Estado == "Activo")
                .ToListAsync();
        }

        public async Task<IEnumerable<Alquiler>> GetAlquileresVencidosAsync()
        {
            return await _context.Alquileres
                .Where(a => a.FechaFin < DateTime.Now && a.FechaDevolucion == null)
                .ToListAsync();
        }

        public async Task<bool> FinalizarAlquilerAsync(int alquilerId, DateTime fechaDevolucion)
        {
            var alquiler = await _context.Alquileres.FindAsync(alquilerId);
            if (alquiler == null) return false;

            alquiler.FechaDevolucion = fechaDevolucion;
            alquiler.Estado = "Finalizado";
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CancelarAlquilerAsync(int alquilerId)
        {
            var alquiler = await _context.Alquileres.FindAsync(alquilerId);
            if (alquiler == null) return false;

            alquiler.Estado = "Cancelado";
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RegistrarMultaAsync(int alquilerId, Multa multa)
        {
            var alquiler = await _context.Alquileres
                .Include(a => a.Multas)
                .FirstOrDefaultAsync(a => a.AlquilerId == alquilerId);

            if (alquiler == null) return false;

            alquiler.Multas.Add(multa);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AgregarPagoAsync(int alquilerId, Pago pago)
        {
            var alquiler = await _context.Alquileres
                .Include(a => a.Pagos)
                .FirstOrDefaultAsync(a => a.AlquilerId == alquilerId);

            if (alquiler == null) return false;

            alquiler.Pagos.Add(pago);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> VerificarDisponibilidadVehiculoAsync(int vehiculoId, DateTime desde, DateTime hasta)
        {
            return !await _context.Alquileres.AnyAsync(a =>
                a.VehiculoId == vehiculoId &&
                a.Estado == "Activo" &&
                ((desde >= a.FechaInicio && desde <= a.FechaFin) ||
                 (hasta >= a.FechaInicio && hasta <= a.FechaFin) ||
                 (desde <= a.FechaInicio && hasta >= a.FechaFin)));
        }

        public async Task<IEnumerable<Alquiler>> GetAlquileresPorVehiculoAsync(int vehiculoId)
        {
            return await _context.Alquileres
                .Where(a => a.VehiculoId == vehiculoId)
                .ToListAsync();
        }

        public async Task<int> ContarAlquileresPorClienteAsync(int clienteId)
        {
            return await _context.Alquileres
                .CountAsync(a => a.ClienteId == clienteId);
        }

        public async Task<decimal> CalcularTotalFacturadoAsync(DateTime desde, DateTime hasta)
        {
            return await _context.Alquileres
                .Where(a => a.FechaInicio >= desde && a.FechaFin <= hasta)
                .SumAsync(a => a.Total);
        }
    }
}