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
        public DbSet<Multa> Multas { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Pago> Pagos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Forzar nombres de tabla en singular para coincidir con la base
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Vehiculo>().ToTable("Vehiculo");
            modelBuilder.Entity<Empleado>().ToTable("Empleado");
            modelBuilder.Entity<Alquiler>().ToTable("Alquiler");
            modelBuilder.Entity<Pago>().ToTable("Pago");
            modelBuilder.Entity<Multa>().ToTable("Multa");
            modelBuilder.Entity<Contacto>().ToTable("Contacto");
           
            base.OnModelCreating(modelBuilder);
        }
    }
}

/*
 ApplicationDbContext es el nombre de tu clase (podría llamarse como vos quieras).
: DbContext - ignifica que estás heredando de la clase base DbContext, que viene con toda la lógica que Entity Framework 
              necesita para manejar conexiones, ejecutar queries, guardar cambios, etc.

lo que le sigue abajo es el constructor que permite inyectar la configuración de conexión desde el program.cs

el DbSet<T> -> Esta clase representa una tabla en tu bdd.

Y por convención:
- Si tu clase se llama Usuario, el DbSet lo llamás Usuarios.
- Si tu clase se llama Vehiculo, lo llamás Vehiculos.
 */