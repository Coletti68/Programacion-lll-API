using RentCars.Api.Data;
using RentCars.Api.Models;
using RentCars.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RentCars.Api.Data.Services.Implementaciones
{
    public class PagoService : IPagoService
    {
        private readonly ApplicationDbContext _context;
        public PagoService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Pago> GetPagoByIdAsync(int id)
        {
            return await _context.Pagos.FindAsync(id);
        }
        public async Task<IEnumerable<Pago>> GetAllPagosAsync()
        {
            return await _context.Pagos.ToListAsync();
        }
        public async Task<Pago> CreatePagoAsync(Pago pago)
        {
            _context.Pagos.Add(pago);
            await _context.SaveChangesAsync();
            return pago;
        }
        public async Task<Pago> UpdatePagoAsync(Pago pago)
        {
            _context.Entry(pago).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return pago;
        }
        public async Task<bool> DeletePagoAsync(int id)
        {
            var pago = await GetPagoByIdAsync(id);
            if (pago == null) return false;
            _context.Pagos.Remove(pago);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<IEnumerable<Pago>> GetPagosByUsuarioIdAsync(int usuarioId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pago>> GetPagosByAlquilerIdAsync(int alquilerId)
        {
            throw new NotImplementedException();
        }
    }
}