namespace RentCars.Api.Models
{
    public class Alquiler
    {
        public int AlquilerId { get; set; }
        public int ClienteId { get; set; }
        public int VehiculoId { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
    }
}
