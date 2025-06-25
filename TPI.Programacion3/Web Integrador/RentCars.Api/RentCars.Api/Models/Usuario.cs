using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentCars.Api.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        [Required]
        public string Nombre_Completo { get; set; }
        [Required]
        public string password { get; set; }
        public string TipoDocumento { get; set; }
        public string DNI { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Pais { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        // Relaciones
        public ICollection<Alquiler> Alquileres { get; set; }
        public ICollection<AceptacionTerminos> Aceptaciones { get; set; }
        public ICollection<Contacto> Contactos { get; set; }

    }
}