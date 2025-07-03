using RentCars.Api.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace RentCars.Api.Services.Interfaces
{
    public interface IContactoService
    {
        Task<IEnumerable<Contacto>> GetAllAsync();
        Task<Contacto?> GetByIdAsync(int id);
        Task<Contacto> CreateAsync(Contacto contacto);
        Task<bool> DeleteAsync(int id);
        Task<Contacto?> MarcarComoRespondidoAsync(int id);
    }
}