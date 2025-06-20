using RentCars.Api.Data;
using RentCars.Api.Models;
using RentCars.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RentCars.Api.Data.Services.Implementaciones
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Usuario> AuthenticateAsync(string email, string password)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public Task<string> GenerateJwtTokenAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsEmailInUseAsync(string email)
        {
            return await _context.Usuarios.AnyAsync(u => u.Email == email);
        }

        public Task<Usuario> LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> RegisterAsync(Usuario usuario, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExistsAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidatePasswordAsync(Usuario usuario, string password)
        {
            throw new NotImplementedException();
        }
    }
}