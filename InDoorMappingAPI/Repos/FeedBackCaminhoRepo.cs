using IndoorMappingAPI.Data;
using IndoorMappingAPI.Models;
using IndoorMappingAPI.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IndoorMappingAPI.Repos
{
    public class FeedbackCaminhoRepo : IFeedbackCaminhoRepo
    {
        private readonly DataContext _context;

        public FeedbackCaminhoRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FeedbackCaminho>> GetAllAsync()
        {
            return await _context.FeedbackCaminhos.Include(f => f.Usuario).ToListAsync();
        }

        public async Task AddAsync(FeedbackCaminho feedback)
        {
            await _context.FeedbackCaminhos.AddAsync(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task<double?> GetMediaPorCaminhoAsync(long caminhoId)
        {
            return await _context.FeedbackCaminhos
                .Where(f => f.CaminhoId == caminhoId)
                .AverageAsync(f => (double?)f.Avaliacao);
        }
    }
}
