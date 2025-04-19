using IndoorMappingAPI.Data;
using IndoorMappingAPI.Models;
using IndoorMappingAPI.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace IndoorMappingAPI.Repos
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
            return await _context.Acessibilidade.ToListAsync();
        }

        public async Task<Acessibilidade> GetByIdAsync(long id)
        {
            return await _context.Acessibilidade.FirstOrDefaultAsync(e => e.AcessibilidadeId == id);
        }

        public async Task AddAsync(Acessibilidade entity)
        {
            await _context.Acessibilidade.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Acessibilidade entity)
        {
            _context.Acessibilidade.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await _context.Acessibilidade.FindAsync(id);
            if (entity != null)
            {
                _context.Acessibilidade.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
