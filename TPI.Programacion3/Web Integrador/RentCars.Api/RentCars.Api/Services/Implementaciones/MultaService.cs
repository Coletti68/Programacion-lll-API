using Microsoft.EntityFrameworkCore;
using RentCars.Api.Data;
using RentCars.Api.DTOs.Multa;
using RentCars.Api.Models;
using RentCars.Api.Services.Interfaces;

namespace RentCars.Api.Services.Implementaciones
{
    public class MultaService : IMultaService
    {
        private readonly ApplicationDbContext _context;

        public MultaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MultaResponse>> GetAllAsync()
        {
            return await _context.Multas
                .Select(m => new MultaResponse
                {
                    MultaId = m.MultaId,
                    AlquilerId = m.AlquilerId,
                    Descripcion = m.Descripcion,
                    Monto = m.Monto,
                    FechaMulta = m.FechaMulta,
                    Estado = m.Estado,
                    Tipo = m.Tipo
                }).ToListAsync();
        }

        public async Task<MultaResponse?> GetByIdAsync(int id)
        {
            var multa = await _context.Multas.FindAsync(id);
            if (multa == null) return null;

            return new MultaResponse
            {
                MultaId = multa.MultaId,
                AlquilerId = multa.AlquilerId,
                Descripcion = multa.Descripcion,
                Monto = multa.Monto,
                FechaMulta = multa.FechaMulta,
                Estado = multa.Estado,
                Tipo = multa.Tipo
            };
        }

        public async Task<MultaResponse> CreateAsync(MultaCreateRequest request)
        {
            var multa = new Multa
            {
                AlquilerId = request.AlquilerId,
                Descripcion = request.Descripcion,
                Monto = request.Monto,
                FechaMulta = request.FechaMulta,
                Estado = request.Estado,
                Tipo = request.Tipo
            };

            _context.Multas.Add(multa);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(multa.MultaId) ?? throw new Exception("No se pudo crear la multa");
        }

        public async Task<MultaResponse?> UpdateAsync(int id, MultaUpdateRequest request)
        {
            var multa = await _context.Multas.FindAsync(id);
            if (multa == null) return null;

            multa.Descripcion = request.Descripcion;
            multa.Monto = request.Monto;
            multa.FechaMulta = request.FechaMulta;
            multa.Estado = request.Estado;
            multa.Tipo = request.Tipo;

            await _context.SaveChangesAsync();
            return await GetByIdAsync(id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var multa = await _context.Multas.FindAsync(id);
            if (multa == null) return false;

            _context.Multas.Remove(multa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
