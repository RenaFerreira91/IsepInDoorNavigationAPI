using InDoorMappingAPI.Data;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InDoorMappingAPI.Repos
{
    public class InfraestruturaRepo : IInfraestruturaRepo
    {
        private readonly DataContext _context;
        public InfraestruturaRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Infraestrutura>> GetAllAsync()
        {
            return await _context.Infraestruturas
                .Include(i => i.TipoInfraestrutura)
                .ToListAsync();
        }

        public async Task<Infraestrutura> GetByIdAsync(long id)
        {
            return await _context.Infraestruturas
                .Include(i => i.TipoInfraestrutura)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task AddAsync(Infraestrutura entity)
        {
            await _context.Infraestruturas.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Infraestrutura entity)
        {
            try
            {
                _context.Infraestruturas.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no UpdateAsync: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await _context.Infraestruturas.FindAsync(id);
            if (entity != null)
            {
                _context.Infraestruturas.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
