namespace RentCars.Api.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public int AlquilerId { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
        public string CodigoReferencia { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Observaciones { get; set; }
    }
}
