using RentCars.Api.Data;
using RentCars.Api.Models;
using RentCars.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RentCars.Api.Data.Services.Implementaciones
{
    public class MultaService : IMultaService
    {
        private readonly ApplicationDbContext _context;
        public MultaService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Multa> GetMultaByIdAsync(int id)
        {
            return await _context.Multas.FindAsync(id);
        }
        public async Task<IEnumerable<Multa>> GetAllMultasAsync()
        {
            return await _context.Multas.ToListAsync();
        }
        public async Task<Multa> CreateMultaAsync(Multa multa)
        {
            _context.Multas.Add(multa);
            await _context.SaveChangesAsync();
            return multa;
        }
        public async Task<Multa> UpdateMultaAsync(Multa multa)
        {
            _context.Entry(multa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return multa;
        }
        public async Task<bool> DeleteMultaAsync(int id)
        {
            var multa = await GetMultaByIdAsync(id);
            if (multa == null) return false;
            _context.Multas.Remove(multa);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Multa>> GetMultasByUsuarioIdAsync(int usuarioId)
        {
            return await _context.Multas.Where(m => m.UsuarioId == usuarioId).ToListAsync();
        }
        public async Task<IEnumerable<Multa>> GetMultasByVehiculoIdAsync(int vehiculoId)
        {
            return await _context.Multas.Where(m => m.VehiculoId == vehiculoId).ToListAsync();
        }
    }

}