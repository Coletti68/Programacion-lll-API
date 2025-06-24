using RentCars.Api.Models;

namespace RentCars.Api.Services.Interfaces
{
    public interface IEmpleadoService
    {
        Task<IEnumerable<Empleado>> GetAllAsync();
        Task<Empleado> GetByIdAsync(int id);
        Task<Empleado> CreateAsync(Empleado empleado);
        Task<Empleado> UpdateAsync(Empleado empleado);
        Task<bool> DeleteAsync(int id);
    }
}