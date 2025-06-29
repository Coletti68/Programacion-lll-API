using System.ComponentModel.DataAnnotations;

namespace RentCars.Api.DTOs.Auth
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}