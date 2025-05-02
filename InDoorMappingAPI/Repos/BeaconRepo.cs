using InDoorMappingAPI.Data;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InDoorMappingAPI.Repos
{
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
            return await _context.Beacons.FindAsync(id);
        }

        public async Task AddAsync(Beacon beacon)
        {
            await _context.Beacons.AddAsync(beacon);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Beacon beacon)
        {
            _context.Beacons.Update(beacon);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var beacon = await _context.Beacons.FindAsync(id);
            if (beacon != null)
            {
                _context.Beacons.Remove(beacon);
                await _context.SaveChangesAsync();
            }
        }
    }
}
