using Microsoft.EntityFrameworkCore;
using RentCars.Api.Data;
using RentCars.Api.Models;
using RentCars.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentCars.Api.Services.Implementaciones
{
    public class VehiculoService : IVehiculoService
    {
        private readonly ApplicationDbContext _context;

        public VehiculoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vehiculo>> GetAllAsync()
        {
            return await _context.Vehiculos.ToListAsync();
        }

        public async Task<Vehiculo?> GetByIdAsync(int id)
        {
            return await _context.Vehiculos.FindAsync(id);
        }

        public async Task<Vehiculo> CreateAsync(Vehiculo vehiculo)
        {
            // Validar que no exista otra placa igual (case-insensitive si querés evitar duplicados del tipo "ABC123" vs "abc123")
            bool placaExiste = await _context.Vehiculos
                .AnyAsync(v => v.Placa.ToLower() == vehiculo.Placa.ToLower());

            if (placaExiste)
                throw new InvalidOperationException("Ya existe un vehículo con esa placa.");

            _context.Vehiculos.Add(vehiculo);
            await _context.SaveChangesAsync();
            return vehiculo;
        }


        public async Task<Vehiculo?> UpdateAsync(int id, Vehiculo vehiculo)
        {
            var existente = await _context.Vehiculos.FindAsync(id);
            if (existente == null) return null;

            existente.Marca = vehiculo.Marca;
            existente.Modelo = vehiculo.Modelo;
            existente.Anio = vehiculo.Anio;
            existente.Placa = vehiculo.Placa;
            existente.Color = vehiculo.Color;
            existente.Tipo = vehiculo.Tipo;
            existente.PrecioPorDia = vehiculo.PrecioPorDia;
            existente.Estado = vehiculo.Estado;

            _context.Vehiculos.Update(existente);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null) return false;

            _context.Vehiculos.Remove(vehiculo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
