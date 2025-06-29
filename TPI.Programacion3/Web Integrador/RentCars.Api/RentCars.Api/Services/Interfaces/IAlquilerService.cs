using RentCars.Api.DTOs.Alquiler;
using RentCars.Api.Models;

namespace RentCars.Api.Services.Interfaces
{
    public interface IAlquilerService
    {
        // CRUD b�sico
        Task<IEnumerable<AlquilerResponse>> GetAllAsync();
        Task<AlquilerResponse?> GetByIdAsync(int id);
        Task<Alquiler> CreateAsync(Alquiler alquiler);
        Task<bool> UpdateAsync(int id, AlquilerUpdate dto);
        Task<bool> DeleteAsync(int id);

        // Consultas espec�ficas
        Task<IEnumerable<Alquiler>> GetByClienteIdAsync(int clienteId);
        Task<IEnumerable<Alquiler>> GetByEstadoAsync(string estado);
        Task<IEnumerable<Alquiler>> GetByRangoFechasAsync(DateTime desde, DateTime hasta);
        Task<IEnumerable<Alquiler>> GetAlquileresActivosAsync();
        Task<IEnumerable<Alquiler>> GetAlquileresVencidosAsync();

        // Operaciones de negocio
        Task<bool> FinalizarAlquilerAsync(int alquilerId, DateTime fechaDevolucion);
        Task<bool> CancelarAlquilerAsync(int alquilerId);
        Task<bool> RegistrarMultaAsync(int alquilerId, Multa multa);
        Task<bool> AgregarPagoAsync(int alquilerId, Pago pago);

        // Validaciones y estad�sticas
        Task<bool> VerificarDisponibilidadVehiculoAsync(int vehiculoId, DateTime desde, DateTime hasta);
        Task<IEnumerable<Alquiler>> GetAlquileresPorVehiculoAsync(int vehiculoId);
        Task<int> ContarAlquileresPorClienteAsync(int clienteId);
        Task<decimal> CalcularTotalFacturadoAsync(DateTime desde, DateTime hasta);
    }
}