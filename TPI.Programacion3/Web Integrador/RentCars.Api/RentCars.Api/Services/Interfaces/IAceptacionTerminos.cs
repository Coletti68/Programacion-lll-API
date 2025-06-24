using RentCars.Api.Models;

namespace RentCars.Api.Services.Interfaces
{
    public interface IAceptacionTerminosService
    {
        Task<IEnumerable<AceptacionTerminos>> GetAllAsync();
        Task<AceptacionTerminos?> GetByIdAsync(int id);
        Task<AceptacionTerminos> CreateAsync(AceptacionTerminos aceptacion);
        Task<bool> DeleteAsync(int id);
    }
}