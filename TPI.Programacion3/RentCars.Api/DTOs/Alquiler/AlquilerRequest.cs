namespace RentCars.Api.DTOs.Alquiler
{
    public class AlquilerRequest
    {
        public int UsuarioId { get; set; }
        public int VehiculoId { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Total { get; set; }
        public bool aceptoTerminos { get; set; } = false;
    }
}