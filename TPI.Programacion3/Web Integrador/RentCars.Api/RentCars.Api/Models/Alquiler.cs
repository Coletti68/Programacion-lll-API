using System;

namespace RentCars.Api.Models
{
    public class Alquiler
    {

        
        public int AlquilerId { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }

        public bool AceptoTerminos { get; set; } = false;

        // Relaciones inversas
        public ICollection<Pago> Pagos { get; set; }
        public ICollection<Multa> Multas { get; set; }

    }
}

//El ? indica que ese tipo es nullable � es decir, puede aceptar un valor nulo (null).
/*�Por qu� hay un objeto debajo de cada clave for�nea? Exacto: ese �objeto� es lo que se llama una propiedad de navegaci�n. 
  - Cliente es la relaci�n completa que te da acceso a todas las propiedades del usuario.
- ener acceso directo al objeto Usuario desde una instancia de Alquiler sin tener que hacer una segunda consulta manual.
- Usar cosas como .Include(x => x.Cliente) en tus consultas con EF Core para traer los datos completos relacionados.
- Que EF Core entienda c�mo est�n relacionadas tus tablas.
*/


