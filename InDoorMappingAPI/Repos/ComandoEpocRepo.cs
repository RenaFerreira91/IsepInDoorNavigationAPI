using InDoorMappingAPI.Data;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InDoorMappingAPI.Repos
{
    public class ComandoEpocRepo : IComandoEpocRepo
    {
        private readonly DataContext _context;

        public ComandoEpocRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ComandoEpoc>> GetAllAsync()
        {
            return await _context.ComandosEpoc.Include(c => c.Usuario).ToListAsync();
        }

        public async Task AddAsync(ComandoEpoc comando)
        {
            await _context.ComandosEpoc.AddAsync(comando);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var comando = await _context.ComandosEpoc.FindAsync(id);
            if (comando == null)
                return false;

            _context.ComandosEpoc.Remove(comando);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
