using InDoorMappingAPI.Data;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace InDoorMappingAPI.Repos
{
    public class UsuarioRepo : IUsuarioRepo
    {
        private readonly DataContext _context;

        public UsuarioRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios
                .Include(u => u.Mobilidade)
                .Include(u => u.TipoUsuario)
                .ToListAsync();
        }

        public async Task<Usuario> GetByIdAsync(long id)
        {
            return await _context.Usuarios
               .Include(u => u.Mobilidade)
               .Include(u => u.TipoUsuario)
               .FirstOrDefaultAsync(u => u.UsuarioId == id);
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var user = await _context.Usuarios.FindAsync(id);
            if (user != null)
            {
                _context.Usuarios.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
