using Microsoft.EntityFrameworkCore;
using RentCars.Api.Data;
using RentCars.Api.Models;
using RentCars.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentCars.Api.Services.Implementaciones
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ApplicationDbContext _context;

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario?> UpdateAsync(int id, Usuario usuario)
        {
            var existente = await _context.Usuarios.FindAsync(id);
            if (existente == null) return null;

            existente.Nombre_Completo = usuario.Nombre_Completo;
            existente.Email = usuario.Email;
            existente.Telefono = usuario.Telefono;
            existente.DNI = usuario.DNI;
            existente.Direccion = usuario.Direccion;

            _context.Usuarios.Update(existente);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}