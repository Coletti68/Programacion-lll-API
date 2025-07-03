using RentCars.Api.DTOs.Alquiler;
using RentCars.Api.Models;

namespace RentCars.Api.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetAllAsync(); //- Devuelve una colección de todos los usuarios de forma asíncrona.
        Task<Usuario?> GetByIdAsync(int id); //- Busca un usuario por su ID en la base de datos. ? = puede ser null si no encuentra
        Task<Usuario> CreateAsync(Usuario usuario); // Recibe un obj Usuario y lo inserta en la bdd
        Task<Usuario> UpdateAsync(int id, Usuario usuario); //Espera un obj usuario ya editado, sino devuelve false
        Task<bool> DesactivarAsync(int id); //Elimina un usuario por us ID, devuelve true si lo encontro y borro, sino false
        Task<IEnumerable<AlquilerResponse>> GetHistorialPorUsuarioAsync(int id);

    }
}
