using Microsoft.EntityFrameworkCore;

namespace RentCars.Api.Models
{
	public class AceptacionTerminos
	{
		public int Id { get; set; }
		public int ClienteId { get; set; }
		public int AlquilerId { get; set; }
		public DateTime FechaAceptacion { get; set; }
		public string VersionTerminos { get; set; } = string.Empty;

        public string IP { get; set; } = string.Empty;
        

    }
}
