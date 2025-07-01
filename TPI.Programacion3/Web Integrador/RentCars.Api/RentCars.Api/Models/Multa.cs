using System;

namespace RentCars.Api.Models
{
    public class Multa
    {
        public int MultaId { get; set; }
        public int AlquilerId { get; set; }
        public Alquiler Alquiler { get; set; }
        public string Descripcion { get; set; } = String.Empty;
        public decimal Monto { get; set; }
        public DateTime FechaMulta { get; set; } = DateTime.Today;
        public string Estado { get; set; }
        public string Tipo { get; set; }

        public DateTime? FechaVencimiento {  get; set; }

    }
}

//datetime.today devuelve la fecha actual, pero con la hora en cero (es decir, a las 00:00:00).