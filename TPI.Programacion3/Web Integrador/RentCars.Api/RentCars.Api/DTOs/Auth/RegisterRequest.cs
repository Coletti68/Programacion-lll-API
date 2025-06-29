using System.ComponentModel.DataAnnotations;

namespace RentCars.Api.DTOs.Auth
{
    public class RegisterRequest
    {
        [Required]
        public string NombreCompleto { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string DNI { get; set; }
    }
}