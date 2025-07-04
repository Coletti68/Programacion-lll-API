using RentCars.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentCars.Api.Services.Interfaces
{
    public interface IVehiculoService
    {
        Task<IEnumerable<Vehiculo>> GetAllAsync();
        Task<Vehiculo?> GetByIdAsync(int id);
        Task<Vehiculo> CreateAsync(Vehiculo vehiculo);
        Task<Vehiculo?> UpdateAsync(int id, Vehiculo vehiculo);
        Task<bool> DeleteAsync(int id);
        Task<bool> CambiarEstadoAsync(int id, string nuevoEstado);
    }
}