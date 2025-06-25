using RentCars.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentCars.Api.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario?> GetByIdAsync(int id);
        Task<Usuario> CreateAsync(Usuario usuario);
        Task<Usuario?> UpdateAsync(int id, Usuario usuario);
        Task<bool> DeleteAsync(int id);
    }
}