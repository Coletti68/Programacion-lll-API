using Microsoft.EntityFrameworkCore;
using RentCars.Api.Data;
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
            return await _context.Usuarios.ToListAsync(); //Accede a la tabla Usuarios del DbContext y convierte los registros en una lista de objetos Usuario.

        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id); //Busca en la bdd ese user por su id
        }

        public async Task<Usuario> CreateAsync(Usuario usuario) //recibe un obj user y lo guarda en la bdd
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario?> UpdateAsync(int id, Usuario usuario)
        {
            var existente = await _context.Usuarios.FindAsync(id);
            if (existente == null) return null;

            existente.Nombre_Completo = usuario.Nombre_Completo;
            existente.password = usuario.password;
            existente.DNI = usuario.DNI;
            existente.FechaNacimiento = usuario.FechaNacimiento;
            existente.Email = usuario.Email;
            existente.Telefono = usuario.Telefono;
            existente.Direccion = usuario.Direccion;

            _context.Usuarios.Update(existente);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteAsync(int id) //borra un usuario por su id
        {
            var usuario = await _context.Usuarios.FindAsync(id); //lo busca en la bdd
            if (usuario == null) return false; //si no existe, para la busqueda ahi

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync(); //lo elimina y guarda los cambios
            return true;
        }
    }
}
