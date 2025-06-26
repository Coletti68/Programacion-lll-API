using Microsoft.EntityFrameworkCore;
using RentCars.Api.Data;
using RentCars.Api.Services.Implementaciones;
using RentCars.Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// 🔌 Agregar el DbContext con la cadena de conexión del appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🧠 Servicios de controladores
builder.Services.AddControllers();

// 📘 Agregar Swagger (documentación de la API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//llamada a la inyeccion de dependencias del servicio de usuario
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IVehiculoService, VehiculoService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<IMultaService, MultaService>();

var app = builder.Build();

// 🌐 Middleware para Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ⚙️ Middleware base
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
