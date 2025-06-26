using RentCars.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentCars.Api.Services.Interfaces
{
    public interface IAceptacionTerminosService
    {
        Task<IEnumerable<AceptacionTerminos>> GetAllAsync();               // Traer todos
        Task<AceptacionTerminos?> GetByIdAsync(int id);                   // Traer por ID
        Task<AceptacionTerminos> CreateAsync(AceptacionTerminos at);      // Crear nueva aceptación
        Task<AceptacionTerminos?> UpdateAsync(int id, AceptacionTerminos at); // (Opcional) Actualizar
        Task<bool> DeleteAsync(int id);                                   // (Opcional) Eliminar
    }
}