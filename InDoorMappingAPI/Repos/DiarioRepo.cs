using IndoorMappingAPI.Data;
using IndoorMappingAPI.Models;
using IndoorMappingAPI.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace IndoorMappingAPI.Repos
{
    public class DiarioRepo : IDiarioRepo
    {
        private readonly DataContext _context;

        public DiarioRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Diario>> GetAllAsync()
        {
            return await _context.Diario.Include(d => d.Usuario).ToListAsync();
        }

        public async Task AddAsync(Diario entrada)
        {
            await _context.Diario.AddAsync(entrada);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var diario = await _context.Diario.FindAsync(id);
            if (diario == null)
                return false;

            _context.Diario.Remove(diario);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
