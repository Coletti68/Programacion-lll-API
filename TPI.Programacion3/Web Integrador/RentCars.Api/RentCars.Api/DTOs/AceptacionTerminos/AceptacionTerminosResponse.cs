using RentCars.Api.DTOs.Aceptacion;

namespace RentCars.Api.DTOs.Aceptacion
{
    public class AceptacionTerminosResponse
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int AlquilerId { get; set; }
        public DateTime FechaAceptacion { get; set; }
        public string VersionTerminos { get; set; }
    }
}