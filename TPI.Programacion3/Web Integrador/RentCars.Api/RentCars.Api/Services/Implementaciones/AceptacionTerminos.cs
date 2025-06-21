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
            => await _context.Aceptaciones.ToListAsync();

        public async Task<AceptacionTerminos> GetByIdAsync(int id)
            => await _context.Aceptaciones.FindAsync(id);

        public async Task<AceptacionTerminos> CreateAsync(AceptacionTerminos aceptacion)
        {
            _context.Aceptaciones.Add(aceptacion);
            await _context.SaveChangesAsync();
            return aceptacion;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var acc = await _context.Aceptaciones.FindAsync(id);
            if (acc == null) return false;

            _context.Aceptaciones.Remove(acc);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
