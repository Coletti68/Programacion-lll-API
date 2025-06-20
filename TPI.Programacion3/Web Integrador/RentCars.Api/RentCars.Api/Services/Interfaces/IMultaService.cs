using RentCars.Api.Models;  

namespace RentCars.Api.Services.Interfaces
{
    public interface IMultaService
    {
        Task<Multa> GetMultaByIdAsync(int id);
        Task<IEnumerable<Multa>> GetAllMultasAsync();
        Task<Multa> CreateMultaAsync(Multa multa);
        Task<Multa> UpdateMultaAsync(Multa multa);
        Task<bool> DeleteMultaAsync(int id);
        Task<IEnumerable<Multa>> GetMultasByUsuarioIdAsync(int usuarioId);
        Task<IEnumerable<Multa>> GetMultasByVehiculoIdAsync(int vehiculoId);
    }
}