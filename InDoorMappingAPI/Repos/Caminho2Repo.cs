using InDoorMappingAPI.Data;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InDoorMappingAPI.Repos
{
    public class Caminho2Repo : ICaminho2Repo
    {
        private readonly DataContext _context;

        public Caminho2Repo(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Caminho2>> GetAllAsync()
        {
            return await _context.Caminhos2.ToListAsync();
        }

        public async Task<Caminho2> GetByIdAsync(long id)
        {
            return await _context.Caminhos2.FindAsync(id);
        }

        public async Task AddAsync(Caminho2 caminho)
        {
            await _context.Caminhos2.AddAsync(caminho);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Caminho2 caminho)
        {
            _context.Caminhos2.Update(caminho);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var caminho = await GetByIdAsync(id);
            if (caminho != null)
            {
                _context.Caminhos2.Remove(caminho);
                await _context.SaveChangesAsync();
            }
        }
    }

}
