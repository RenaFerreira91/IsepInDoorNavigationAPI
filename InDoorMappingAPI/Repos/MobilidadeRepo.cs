using IndoorMappingAPI.Data;
using IndoorMappingAPI.Models;
using Microsoft.EntityFrameworkCore;

public class MobilidadeRepo : IMobilidadeRepo
{
    private readonly DataContext _context;

    public MobilidadeRepo(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Mobilidade>> GetAllAsync()
    {
        return await _context.Mobilidades.ToListAsync();
    }

    public async Task<Mobilidade> GetByIdAsync(long id)
    {
        return await _context.Mobilidades.FirstOrDefaultAsync(e => e.MobilidadeId == id);
    }

    public async Task AddAsync(Mobilidade entity)
    {
        await _context.Mobilidades.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Mobilidade entity)
    {
        _context.Mobilidades.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var entity = await _context.Mobilidades.FindAsync(id);
        if (entity != null)
        {
            _context.Mobilidades.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
