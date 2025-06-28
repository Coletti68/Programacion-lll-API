namespace RentCars.Api.DTOs.Alquiler
{
    public class AlquilerRegistroDTO
    {
        public int UsuarioId { get; set; }
        public int VehiculoId { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
    }
}
