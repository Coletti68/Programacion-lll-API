using RentCars.Api.Models;

namespace RentCars.Api.Services.Interfaces
{
    public interface IVehiculoService
    {
        Task<Vehiculo> GetVehiculoByIdAsync(int id);
        Task<IEnumerable<Vehiculo>> GetAllVehiculosAsync();
        Task<Vehiculo> CreateVehiculoAsync(Vehiculo vehiculo);
        Task<Vehiculo> UpdateVehiculoAsync(Vehiculo vehiculo);
        Task<bool> DeleteVehiculoAsync(int id);
        Task<IEnumerable<Vehiculo>> GetVehiculosByUsuarioIdAsync(int usuarioId);
        Task<IEnumerable<Vehiculo>> GetVehiculosByMarcaAsync(string marca);
        Task<IEnumerable<Vehiculo>> GetVehiculosByModeloAsync(string modelo);
    }
}   