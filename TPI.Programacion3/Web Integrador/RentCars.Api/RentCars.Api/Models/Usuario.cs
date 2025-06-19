namespace RentCars.Api.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre_Completo { get; set; }
        public string TipoDocumento { get; set; }
        public string DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Pais { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}

