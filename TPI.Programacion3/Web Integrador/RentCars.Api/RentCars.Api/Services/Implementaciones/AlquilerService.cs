using RentCars.Api.Data;
using RentCars.Api.Models;
using RentCars.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RentCars.Api.Data.Services.Implementaciones
{
    public class AlquilerService : IAlquilerService
    {
        private readonly ApplicationDbContext _context;
        public AlquilerService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Alquiler> GetAlquilerByIdAsync(int id)
        {
            return await _context.Alquileres.FindAsync(id);
        }
        public async Task<IEnumerable<Alquiler>> GetAllAlquileresAsync()
        {
            return await _context.Alquileres.ToListAsync();
        }
        public async Task<Alquiler> CreateAlquilerAsync(Alquiler alquiler)
        {
            _context.Alquileres.Add(alquiler);
            await _context.SaveChangesAsync();
            return alquiler;
        }
        public async Task<Alquiler> UpdateAlquilerAsync(Alquiler alquiler)
        {
            _context.Entry(alquiler).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return alquiler;
        }
        public async Task<bool> DeleteAlquilerAsync(int id)
        {
            var alquiler = await GetAlquilerByIdAsync(id);
            if (alquiler == null) return false;
            _context.Alquileres.Remove(alquiler);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<IEnumerable<Alquiler>> GetAlquileresByUsuarioIdAsync(int usuarioId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Alquiler>> GetAlquileresByVehiculoIdAsync(int vehiculoId)
        {
            throw new NotImplementedException();
        }
    }
}