using System.ComponentModel.DataAnnotations;

namespace RentCars.Api.DTOs.Auth
{
    public class RegisterRequest
    {
        [Required]
        public string NombreCompleto { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; }  = string.Empty;

        public string DNI { get; set; } = string.Empty;
    }
}