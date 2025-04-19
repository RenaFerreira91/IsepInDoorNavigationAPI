using IndoorMappingAPI.Data;
using IndoorMappingAPI.Models;
using Microsoft.EntityFrameworkCore;

public class LogRepo : ILogRepo
{
    private readonly DataContext _context;

    public LogRepo(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Log>> GetAllAsync()
    {
        return await _context.Logs.ToListAsync();
    }

    public async Task<Log> GetByIdAsync(long id)
    {
        return await _context.Logs.FirstOrDefaultAsync(e => e.LogId == id);
    }

    public async Task AddAsync(Log entity)
    {
        await _context.Logs.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Log entity)
    {
        _context.Logs.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var entity = await _context.Logs.FindAsync(id);
        if (entity != null)
        {
            _context.Logs.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
