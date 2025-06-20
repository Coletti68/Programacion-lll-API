namespace RentCars.Api.Models
{
    public class Multa
    {
        public int Id { get; set; }
        public int AlquilerId { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaMulta { get; set; }
        public string Estado { get; set; }
        public string Tipo { get; set; }
        public int UsuarioId { get; internal set; }
        public int VehiculoId { get; internal set; }
    }
}
