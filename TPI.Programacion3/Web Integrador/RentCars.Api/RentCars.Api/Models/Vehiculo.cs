using System.ComponentModel.DataAnnotations;    

namespace RentCars.Api.Models
{
    public class Vehiculo
    {
        public int VehiculoId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string Placa { get; set; }
        public string Color { get; set; }
        public string Tipo { get; set; }
        public decimal PrecioPorDia { get; set; }
        public string Estado { get; set; }

        //Relacion inversa
        public ICollection<Alquiler> Alquileres { get; set; }
    }
}
