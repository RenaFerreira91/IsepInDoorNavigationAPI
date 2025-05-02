using InDoorMappingAPI.Data;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InDoorMappingAPI.Repos
{
    public class AcessibilidadeRepo : IAcessibilidadeRepo
    {
        private readonly DataContext _context;

        public AcessibilidadeRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Acessibilidade>> GetAllAsync()
        {
            return await _context.Acessibilidades.ToListAsync();
        }

        public async Task<Acessibilidade> GetByIdAsync(long id)
        {
            return await _context.Acessibilidades.FindAsync(id);
        }

        public async Task AddAsync(Acessibilidade entity)
        {
            await _context.Acessibilidades.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Acessibilidade entity)
        {
            _context.Acessibilidades.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await _context.Acessibilidades.FindAsync(id);
            if (entity != null)
            {
                _context.Acessibilidades.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }

}
