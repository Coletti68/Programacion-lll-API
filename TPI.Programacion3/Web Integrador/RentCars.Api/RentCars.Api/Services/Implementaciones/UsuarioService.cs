using RentCars.Api.Data;
using RentCars.Api.Models;  
using RentCars.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RentCars.Api.Services.Implementaciones
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ApplicationDbContext _context;
        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }
        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }
        public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
        public async Task<Usuario> UpdateUsuarioAsync(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return usuario;
        }
        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            var usuario = await GetUsuarioByIdAsync(id);
            if (usuario == null) return false;
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Usuario> AuthenticateAsync(string email, string password)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
        public async Task<bool> IsEmailInUseAsync(string email)
        {
            return await _context.Usuarios.AnyAsync(u => u.Email == email);
        }
    }
}
