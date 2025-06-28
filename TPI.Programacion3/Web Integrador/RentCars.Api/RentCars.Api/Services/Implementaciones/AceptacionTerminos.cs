using Microsoft.EntityFrameworkCore;
using RentCars.Api.Data;
using RentCars.Api.Models;
using RentCars.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentCars.Api.Services.Implementaciones
{
    public class AceptacionTerminosService : IAceptacionTerminosService
    {
        private readonly ApplicationDbContext _context;

        public AceptacionTerminosService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AceptacionTerminos>> GetAllAsync()
        {
            return await _context.AceptacionesTerminos.ToListAsync();
        }

        public async Task<AceptacionTerminos?> GetByIdAsync(int id)
        {
            return await _context.AceptacionesTerminos.FindAsync(id);
        }

        public async Task<AceptacionTerminos> CreateAsync(AceptacionTerminos at)
        {
            _context.AceptacionesTerminos.Add(at);
            await _context.SaveChangesAsync();
            return at;
        }

        public async Task<AceptacionTerminos?> UpdateAsync(int id, AceptacionTerminos at)
        {
            var existente = await _context.AceptacionesTerminos.FindAsync(id);
            if (existente == null) return null;

            existente.AlquilerId = at.AlquilerId;
            existente.UsuarioId = at.UsuarioId;
            existente.FechaAceptacion = at.FechaAceptacion;
            existente.VersionTerminos = at.VersionTerminos;
            existente.IP = at.IP;

            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var registro = await _context.AceptacionesTerminos.FindAsync(id);
            if (registro == null) return false;

            _context.AceptacionesTerminos.Remove(registro);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}