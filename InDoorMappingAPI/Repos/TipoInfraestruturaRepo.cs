using InDoorMappingAPI.Data;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InDoorMappingAPI.Repos
{
    public class TipoInfraestruturaRepo : ITipoInfraestruturaRepo
    {
        private readonly DataContext _context;

        public TipoInfraestruturaRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoInfraestrutura>> GetAllAsync()
        {
            return await _context.TiposInfraestruturas.ToListAsync();
        }

        public async Task<TipoInfraestrutura> GetByIdAsync(long id)
        {
            return await _context.TiposInfraestruturas.FindAsync(id);
        }

        public async Task AddAsync(TipoInfraestrutura entity)
        {
            await _context.TiposInfraestruturas.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TipoInfraestrutura entity)
        {
            _context.TiposInfraestruturas.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await _context.TiposInfraestruturas.FindAsync(id);
            if (entity != null)
            {
                _context.TiposInfraestruturas.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
