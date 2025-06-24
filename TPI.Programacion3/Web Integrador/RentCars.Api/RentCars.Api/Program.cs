using Microsoft.EntityFrameworkCore;
using RentCars.Api.Data;
using RentCars.Api.Services.Interfaces;
using RentCars.Api.Services.Implementaciones;
using RentCars.Api.Data.Services.Implementaciones;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar cadena de conexión
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Agregar controladores
builder.Services.AddControllers();

// 3. Agregar Swagger (OpenAPI)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 4. Inyección de dependencias (services)
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IVehiculoService, VehiculoService>();
builder.Services.AddScoped<IAlquilerService, AlquilerService>();
builder.Services.AddScoped<IAceptacionTerminosService, AceptacionTerminosService>();
builder.Services.AddScoped<IPagoService, PagoService>();
builder.Services.AddScoped<IMultaService, MultaService>();
builder.Services.AddScoped<IContactoService, ContactoService>();
//builder.Services.AddScoped<IQRService, QRService>();

// 5. CORS (opcional, para permitir peticiones desde frontend o Android)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

// 6. Middleware

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

/*
Esto funciona, pero no configura:

la conexión a la base de datos

los servicios inyectables como IAuthService

Swagger para probar endpoints

CORS para permitir frontend o app móvil

validaciones, logs, etc.

—

📄 Program.cs "completo" (el que te di):
Incluye todo eso y más:

builder.Services.AddDbContext → conecta a SQL Server

builder.Services.AddScoped → registra tus servicios (autenticación, alquileres, etc.)

builder.Services.AddCors → habilita acceso desde la web o Android

Swagger → para probar visualmente la API
*/
