using RentCars.Api.DTOs.Alquiler;
using RentCars.Api.Models;

namespace RentCars.Api.Services.Interfaces
{
    public interface IAlquilerService
    {
        // CRUD básico

        Task<List<Alquiler>> GetAllDetalladoAsync();

        Task<IEnumerable<AlquilerResponse>> GetAllAsync();
        Task<AlquilerResponse?> GetByIdAsync(int id);
        Task<Alquiler> CreateAsync(Alquiler alquiler);
        Task<bool> UpdateAsync(int id, AlquilerUpdate dto);
        Task<bool> DeleteAsync(int id);

        // Consultas específicas
        Task<IEnumerable<Alquiler>> GetByUsuarioIdAsync(int id);
        Task<IEnumerable<Alquiler>> GetByEstadoAsync(string estado);
        Task<IEnumerable<Alquiler>> GetByRangoFechasAsync(DateTime desde, DateTime hasta);
        Task<IEnumerable<Alquiler>> GetAlquileresActivosAsync(int? id);
        Task<IEnumerable<Alquiler>> GetAlquileresVencidosAsync();

        // Operaciones de negocio
        Task<bool> FinalizarAlquilerAsync(int alquilerId, DateTime FechaFin);
        Task<bool> CancelarAlquilerAsync(int alquilerId);

        // Validaciones y estadísticas
        Task<bool> VerificarDisponibilidadVehiculoAsync(int vehiculoId, DateTime desde, DateTime hasta);
        Task<IEnumerable<Alquiler>> GetAlquileresPorVehiculoAsync(int vehiculoId);
        Task<int> ContarAlquileresPorUsuarioAsync(int id);
        Task<decimal> CalcularTotalFacturadoAsync(DateTime desde, DateTime hasta);
        Task<int> FinalizarAlquileresVencidosAsync();

        //Task<FacturaAlquilerDTO?> GenerarFacturaDTOAsync(int alquilerId);

    }
}