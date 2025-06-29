using System.ComponentModel.DataAnnotations;

namespace RentCars.Api.DTOs.Auth
{
    public class ResetPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public string NuevaPassword { get; set; }
    }
}