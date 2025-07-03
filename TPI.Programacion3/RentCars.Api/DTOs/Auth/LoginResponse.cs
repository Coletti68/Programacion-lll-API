namespace RentCars.Api.DTOs.Auth
{
    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Expira { get; set; }
    }
}