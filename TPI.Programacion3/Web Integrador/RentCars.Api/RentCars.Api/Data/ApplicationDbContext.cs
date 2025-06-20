using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore;
using RentCars.Api.Models;

namespace RentCars.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Alquiler> Alquileres { get; set; }
        public DbSet<AceptacionTerminos> Aceptaciones { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Multa> Multas { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
    }
}
