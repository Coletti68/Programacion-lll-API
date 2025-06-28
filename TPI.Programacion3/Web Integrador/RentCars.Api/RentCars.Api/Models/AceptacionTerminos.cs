using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace RentCars.Api.Models
{
	public class AceptacionTerminos
	{
		public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int AlquilerId { get; set; }
		public Alquiler Alquiler { get; set; }
        public DateTime FechaAceptacion { get; set; } = DateTime.Now;
        public string VersionTerminos { get; set; } =  "v1.0";
        public string IP { get; set; }
    }
}
