using RentCars.Api.Data;
using RentCars.Api.Models;
using RentCars.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RentCars.Api.Data.Services.Implementaciones
{
    public class ContactoService : IContactoService
    {
        private readonly ApplicationDbContext _context;
        public ContactoService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Contacto> GetContactoByIdAsync(int id)
        {
            return await _context.Contactos.FindAsync(id);
        }
        public async Task<IEnumerable<Contacto>> GetAllContactosAsync()
        {
            return await _context.Contactos.ToListAsync();
        }
        public async Task<Contacto> CreateContactoAsync(Contacto contacto)
        {
            _context.Contactos.Add(contacto);
            await _context.SaveChangesAsync();
            return contacto;
        }
        public async Task<Contacto> UpdateContactoAsync(Contacto contacto)
        {
            _context.Entry(contacto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return contacto;
        }
        public async Task<bool> DeleteContactoAsync(int id)
        {
            var contacto = await GetContactoByIdAsync(id);
            if (contacto == null) return false;
            _context.Contactos.Remove(contacto);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<IEnumerable<Contacto>> GetContactosByUsuarioIdAsync(int usuarioId)
        {
            throw new NotImplementedException();
        }
    }
}