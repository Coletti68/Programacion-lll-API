using RentCars.Api.Models;

namespace RentCars.Api.Services.Interfaces
{
    public interface IContactoService
    {
        Task<Contacto> GetContactoByIdAsync(int id);
        Task<IEnumerable<Contacto>> GetAllContactosAsync();
        Task<Contacto> CreateContactoAsync(Contacto contacto);
        Task<Contacto> UpdateContactoAsync(Contacto contacto);
        Task<bool> DeleteContactoAsync(int id);
        Task<IEnumerable<Contacto>> GetContactosByUsuarioIdAsync(int usuarioId);
    }
}