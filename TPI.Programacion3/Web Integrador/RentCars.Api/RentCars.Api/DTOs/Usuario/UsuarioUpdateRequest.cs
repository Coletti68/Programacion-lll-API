namespace RentCars.Api.DTOs.Usuario
{
    public class UsuarioUpdateDTO
    {
        public int UsuarioId { get; set; }
        public string? NombreCompleto { get; set; }
        public string? TipoDocumento { get; set; }
        public string? DNI { get; set; }
        public string? FechaNacimiento { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Pais { get; set; }
        public string? Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string? password { get; set; } // Solo si decide cambiarla

    }

}
