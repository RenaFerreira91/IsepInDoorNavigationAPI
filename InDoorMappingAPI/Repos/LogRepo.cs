using InDoorMappingAPI.Data;
using InDoorMappingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InDoorMappingAPI.Repos
{
    public class LogRepo : ILogRepo
    {
        private readonly DataContext _context;

        public LogRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Log>> GetAllAsync()
        {
            return await _context.Logs.Include(l => l.Usuario).ToListAsync();
        }

        public async Task<List<Log>> GetFilteredAsync(string? acao, string? usuarioNome)
        {
            var query = _context.Logs.Include(l => l.Usuario).AsQueryable();

            if (!string.IsNullOrEmpty(acao))
                query = query.Where(l => l.Acao.Contains(acao));

            if (!string.IsNullOrEmpty(usuarioNome))
                query = query.Where(l => l.Usuario != null && l.Usuario.Nome.Contains(usuarioNome));

            return await query.ToListAsync();
        }

        public async Task<Log> GetByIdAsync(long id)
        {
            return await _context.Logs.Include(l => l.Usuario).FirstOrDefaultAsync(l => l.LogId == id);
        }

        public async Task AddAsync(Log log)
        {
            await _context.Logs.AddAsync(log);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var log = await _context.Logs.FindAsync(id);
            if (log != null)
            {
                _context.Logs.Remove(log);
                await _context.SaveChangesAsync();
            }
        }
    } 
}
