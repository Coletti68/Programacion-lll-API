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
        public DbSet<AceptacionTerminos> Aceptaciones { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AceptacionTerminos>()
            .HasOne(a => a.Cliente)
            .WithMany()
            .HasForeignKey(a => a.ClienteId)
            .OnDelete(DeleteBehavior.Restrict); // Esto evita la cascada
            // Acá podés agregar reglas personalizadas si necesitás afinar relaciones
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