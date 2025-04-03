using InDoorMappingAPI.Data;
using InDoorMappingAPI.Models;
using Microsoft.EntityFrameworkCore;

public class BeaconRepo : IBeaconRepo
{
    private readonly DataContext _context;

    public BeaconRepo(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Beacon>> GetAllAsync()
    {
        return await _context.Beacons.ToListAsync();
    }

    public async Task<Beacon> GetByIdAsync(long id)
    {
        return await _context.Beacons.FirstOrDefaultAsync(e => e.BeaconId == id);
    }

    public async Task AddAsync(Beacon entity)
    {
        await _context.Beacons.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Beacon entity)
    {
        _context.Beacons.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var entity = await _context.Beacons.FindAsync(id);
        if (entity != null)
        {
            _context.Beacons.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}