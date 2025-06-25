using System;

    namespace RentCars.Api.Models
{ 
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string Nombre_Completo { get; set; }
        public string Cargo { get; set; }
        public string DNI { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Sucursal { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool Activo { get; set; }

        public ICollection<Alquiler> Alquileres { get; set; }

    }
}

