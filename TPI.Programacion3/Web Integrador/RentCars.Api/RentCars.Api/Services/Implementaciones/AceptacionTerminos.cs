using Microsoft.EntityFrameworkCore;
using RentCars.Api.Data;
using RentCars.Api.Models;
using RentCars.Api.Services.Interfaces;

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
            return await _context.AceptacionTerminos.ToListAsync();
        }

        public async Task<AceptacionTerminos?> GetByIdAsync(int id)
        {
            return await _context.AceptacionTerminos.FindAsync(id);
        }

        public async Task<AceptacionTerminos> CreateAsync(AceptacionTerminos aceptacion)
        {
            _context.AceptacionTerminos.Add(aceptacion);
            await _context.SaveChangesAsync();
            return aceptacion;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var terminos = await _context.AceptacionTerminos.FindAsync(id);
            if (terminos == null) return false;

            _context.AceptacionTerminos.Remove(terminos);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
