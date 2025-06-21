using RentCars.Api.Models;

namespace RentCars.Api.Services.Interfaces
{
    public interface IEmpleadoService
    {
        Task<Empleado> GetEmpleadoByIdAsync(int id);
        Task<IEnumerable<Empleado>> GetAllEmpleadosAsync();
        Task<Empleado> CreateEmpleadoAsync(Empleado empleado);
        Task<Empleado> UpdateEmpleadoAsync(Empleado empleado);
        Task<bool> DeleteEmpleadoAsync(int id);
        Task<bool> IsEmailInUseAsync(string email);
    }
}