using InDoorMappingAPI.Data;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InDoorMappingAPI.Repos
{
    public class FeedbackForUserRepo : IFeedbackForUserRepo
    {
        private readonly DataContext _context;

        public FeedbackForUserRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FeedbackForUser>> GetAllAsync()
        {
            return await _context.FeedbacksForUsers.ToListAsync();
        }

        public async Task<FeedbackForUser?> GetByIdAsync(long id)
        {
            return await _context.FeedbacksForUsers.FindAsync(id);
        }

        public async Task AddAsync(FeedbackForUser feedback)
        {
            await _context.FeedbacksForUsers.AddAsync(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await _context.FeedbacksForUsers.FindAsync(id);
            if (entity != null)
            {
                _context.FeedbacksForUsers.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateAsync(FeedbackForUser feedback)
        {
            _context.FeedbacksForUsers.Update(feedback);
            await _context.SaveChangesAsync();
        }
    }
}

