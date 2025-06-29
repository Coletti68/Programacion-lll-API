namespace RentCars.Api.DTOs.Usuario
{
    public class UsuarioUpdateRequestDTO
    {
        public string? NombreCompleto { get; set; }
        public string? TipoDocumento { get; set; }
        public string? DNI { get; set; }
        public string? FechaNacimiento { get; set; } // podr�a ser DateTime? si valid�s antes
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Pais { get; set; }
        public string? Direccion { get; set; }
        public string? Password { get; set; } // capitalizado por convenci�n
    }
}
