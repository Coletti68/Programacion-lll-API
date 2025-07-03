using Microsoft.EntityFrameworkCore;
using RentCars.Api.Data;
using RentCars.Api.DTOs.Alquiler;
using RentCars.Api.Models;
using RentCars.Api.Services.Interfaces;

namespace RentCars.Api.Services.Implementaciones
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ApplicationDbContext _context;

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            var reglasDni = new Dictionary<string, int>
    {
        { "Argentina", 8 },
        { "Brasil", 11 },
        { "Paraguay", 6 },
        { "Chile", 9 }
    };

            if (reglasDni.TryGetValue(usuario.Pais, out var longitudEsperada))
            {
                if (usuario.DNI == null || usuario.DNI.Length != longitudEsperada)
                    throw new Exception($"El DNI debe tener {longitudEsperada} dígitos para {usuario.Pais}.");
            }

            // 🔍 Validar que el DNI no exista
            var dniExistente = await _context.Usuarios.AnyAsync(u => u.DNI == usuario.DNI);
            if (dniExistente)
                throw new Exception("Ya existe un usuario con ese DNI.");

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario?> UpdateAsync(int id, Usuario usuario)
        {
            var existente = await _context.Usuarios.FindAsync(id);
            if (existente == null) return null;

            existente.Nombre_Completo = usuario.Nombre_Completo;
            existente.PasswordHash = usuario.PasswordHash;
            existente.DNI = usuario.DNI;
            existente.FechaNacimiento = usuario.FechaNacimiento;
            existente.Email = usuario.Email;
            existente.Telefono = usuario.Telefono;
            existente.Direccion = usuario.Direccion;

            _context.Usuarios.Update(existente);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DesactivarAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return false;

            usuario.Activo = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<AlquilerResponse>> GetHistorialPorUsuarioAsync(int id)
        {
            return await _context.Alquileres
                .Where(a => a.UsuarioId == id)
                .Include(a => a.Vehiculo)
                .OrderByDescending(a => a.FechaInicio)
                .Select(a => new AlquilerResponse
                {
                    AlquilerId = a.AlquilerId,
                    Vehiculo = a.Vehiculo.Marca + " " + a.Vehiculo.Modelo,
                    FechaInicio = a.FechaInicio,
                    FechaFin = a.FechaFin,
                    Total = a.Total,
                    Estado = a.Estado
                })
                .ToListAsync();
        }
    }
}

