using RentCars.Api.Models;

namespace RentCars.Api.Services.Interfaces
{
    public interface IPagoService
    {
        Task<Pago> GetPagoByIdAsync(int id);
        Task<IEnumerable<Pago>> GetAllPagosAsync();
        Task<Pago> CreatePagoAsync(Pago pago);
        Task<Pago> UpdatePagoAsync(Pago pago);
        Task<bool> DeletePagoAsync(int id);
        Task<IEnumerable<Pago>> GetPagosByUsuarioIdAsync(int usuarioId);
        Task<IEnumerable<Pago>> GetPagosByAlquilerIdAsync(int alquilerId);
    }
}