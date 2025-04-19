using IndoorMappingAPI.Models;

namespace IndoorMappingAPI.Repos.Interfaces
{
    public interface IFeedbackCaminhoRepo
    {
        Task AddAsync(FeedbackCaminho feedback);
        Task<IEnumerable<FeedbackCaminho>> GetAllAsync();
        Task<double?> GetMediaPorCaminhoAsync(long caminhoId);
    }
}