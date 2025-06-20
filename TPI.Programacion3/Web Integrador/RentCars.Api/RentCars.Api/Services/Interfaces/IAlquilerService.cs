using RentCars.Api.Models;

namespace RentCars.Api.Services.Interfaces
{
    public interface IAlquilerService
    {
        Task<Alquiler> GetAlquilerByIdAsync(int id);
        Task<IEnumerable<Alquiler>> GetAllAlquileresAsync();
        Task<Alquiler> CreateAlquilerAsync(Alquiler alquiler);
        Task<Alquiler> UpdateAlquilerAsync(Alquiler alquiler);
        Task<bool> DeleteAlquilerAsync(int id);
        Task<IEnumerable<Alquiler>> GetAlquileresByUsuarioIdAsync(int usuarioId);
        Task<IEnumerable<Alquiler>> GetAlquileresByVehiculoIdAsync(int vehiculoId);
    }
}