using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using RentCars.Api.Data;
using RentCars.Api.Services.Implementaciones;
using RentCars.Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// 🔌 DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🧠 Controladores
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// 📘 Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔐 Servicios (DI)
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IVehiculoService, VehiculoService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<IMultaService, MultaService>();
builder.Services.AddScoped<IContactoService, ContactoService>();
builder.Services.AddScoped<IPagoService, PagoService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAlquilerService, AlquilerService>();

// 🌍 Habilitar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// 🌐 Swagger (solo en desarrollo)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🛡️ Activar CORS antes de MapControllers
app.UseCors("PermitirFrontend");

// ⚙️ Middleware base
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();