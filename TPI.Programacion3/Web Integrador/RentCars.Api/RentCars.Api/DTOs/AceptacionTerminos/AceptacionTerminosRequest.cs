using RentCars.Api.DTOs.Aceptacion;

namespace RentCars.Api.DTOs.Aceptacion
{
    public class AceptacionTerminosRequest
    {
        public int UsuarioId { get; set; }
        public int AlquilerId { get; set; }
        public string VersionTerminos { get; set; } = "v1.0";
        public string IP { get; set; }
    }
}