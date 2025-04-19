using IndoorMappingAPI.Models;
using IndoorMappingAPI.Repos;
using IndoorMappingAPI.Repos.Interfaces;
using IndoorMappingAPI.Services.Interfaces;

namespace IndoorMappingAPI.Services
{
    public class FeedbackCaminhoService : IFeedbackCaminhoService
    {
        private readonly IFeedbackCaminhoRepo _repo;

        public FeedbackCaminhoService(IFeedbackCaminhoRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<FeedbackCaminho>> GetAllAsync(long? caminhoId = null)
        {
            var lista = await _repo.GetAllAsync();
            return caminhoId.HasValue
                ? lista.Where(f => f.CaminhoId == caminhoId)
                : lista;
        }

        public async Task AddAsync(FeedbackCaminho feedback)
        {
            await _repo.AddAsync(feedback);
        }

        public async Task<double?> GetMediaPorCaminhoAsync(long caminhoId)
        {
            return await _repo.GetMediaPorCaminhoAsync(caminhoId);
        }
    }
}
