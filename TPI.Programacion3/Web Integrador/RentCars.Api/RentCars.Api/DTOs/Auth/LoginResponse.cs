namespace RentCars.Api.DTOs.Auth
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public DateTime Expira { get; set; }
    }
}