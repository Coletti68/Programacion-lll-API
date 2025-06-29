using RentCars.Api.Models;
using System.ComponentModel.DataAnnotations;

public class Usuario
{
    public int UsuarioId { get; set; }

    [Required]
    public string Nombre_Completo { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    public string? TipoDocumento { get; set; }

    public string? DNI { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? Telefono { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public string? Pais { get; set; }

    public string? Direccion { get; set; }

    public DateTime FechaRegistro { get; set; } = DateTime.Now;

    public string Rol { get; set; } = "Usuario";

    public string? ResetToken { get; set; }

    public DateTime? ResetTokenExpira { get; set; }

    // Relaciones
    public ICollection<Alquiler>? Alquileres { get; set; }

    public ICollection<Contacto>? Contactos { get; set; }
}