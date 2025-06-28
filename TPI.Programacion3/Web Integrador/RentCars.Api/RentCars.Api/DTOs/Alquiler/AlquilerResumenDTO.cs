
namespace RentCars.Api.DTOs.Alquiler
{ 
  public class AlquilerResumenDTO
  {
    public int AlquilerId { get; set; }
    public string UsuarioNombre { get; set; } = string.Empty;
    public string Vehiculo { get; set; } = string.Empty;
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public decimal Total { get; set; }
    public string Estado { get; set; } = string.Empty;
  }
}