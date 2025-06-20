using RentCars.Api.Models;    

namespace RentCars.Api.Services.Interfaces
{
    public interface IAuthService
    {
        Task<Usuario> RegisterAsync(Usuario usuario, string password);
        Task<Usuario> LoginAsync(string email, string password);
        Task<bool> UserExistsAsync(string email);
        Task<string> GenerateJwtTokenAsync(Usuario usuario);
        Task<bool> ValidatePasswordAsync(Usuario usuario, string password);
    }
}