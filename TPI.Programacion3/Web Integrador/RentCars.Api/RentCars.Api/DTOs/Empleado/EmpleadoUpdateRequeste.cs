using System;
using System.ComponentModel.DataAnnotations;

namespace RentCars.Api.DTOs.Empleado
{
    public class EmpleadoUpdateRequest
    {
        [Required]
        public string Nombre_Completo { get; set; }

        [Required]
        public string Cargo { get; set; }

        [Required]
        public string DNI { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Sucursal { get; set; }

        public bool Activo { get; set; }
    }
}
