using InDoorMappingAPI.Data;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InDoorMappingAPI.Repos
{
    public class RecoveryTokenRepo : IRecoveryTokenRepo
    {
        private readonly DataContext _context;

        public RecoveryTokenRepo(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(RecoveryToken token)
        {
            await _context.RecoveryTokens.AddAsync(token);
            await _context.SaveChangesAsync();
        }

        public async Task<RecoveryToken?> GetValidTokenAsync(string token)
        {
            return await _context.RecoveryTokens
                .FirstOrDefaultAsync(r => r.Token == token && r.Expiration > DateTime.UtcNow);
        }

        public async Task DeleteAsync(RecoveryToken token)
        {
            _context.RecoveryTokens.Remove(token);
            await _context.SaveChangesAsync();
        }
    }

}
