using RentCars.Api.Models;

namespace RentCars.Api.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuarioByIdAsync(int id);
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
        Task<Usuario> CreateUsuarioAsync(Usuario usuario);
        Task<Usuario> UpdateUsuarioAsync(Usuario usuario);
        Task<bool> DeleteUsuarioAsync(int id);
        Task<Usuario> AuthenticateAsync(string email, string password);
        Task<bool> IsEmailInUseAsync(string email);
    }
}   