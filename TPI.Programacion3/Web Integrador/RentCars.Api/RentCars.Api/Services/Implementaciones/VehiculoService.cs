using RentCars.Api.Data;
using RentCars.Api.Models;
using RentCars.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RentCars.Api.Data.Services.Implementaciones
{
    public class VehiculoService : IVehiculoService
    {
        private readonly ApplicationDbContext _context;
        public VehiculoService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Vehiculo> GetVehiculoByIdAsync(int id)
        {
            return await _context.Vehiculos.FindAsync(id);
        }
        public async Task<IEnumerable<Vehiculo>> GetAllVehiculosAsync()
        {
            return await _context.Vehiculos.ToListAsync();
        }
        public async Task<Vehiculo> CreateVehiculoAsync(Vehiculo vehiculo)
        {
            _context.Vehiculos.Add(vehiculo);
            await _context.SaveChangesAsync();
            return vehiculo;
        }
        public async Task<Vehiculo> UpdateVehiculoAsync(Vehiculo vehiculo)
        {
            _context.Entry(vehiculo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return vehiculo;
        }
        public async Task<bool> DeleteVehiculoAsync(int id)
        {
            var vehiculo = await GetVehiculoByIdAsync(id);
            if (vehiculo == null) return false;
            _context.Vehiculos.Remove(vehiculo);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<IEnumerable<Vehiculo>> GetVehiculosByUsuarioIdAsync(int usuarioId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vehiculo>> GetVehiculosByMarcaAsync(string marca)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vehiculo>> GetVehiculosByModeloAsync(string modelo)
        {
            throw new NotImplementedException();
        }
    }
}