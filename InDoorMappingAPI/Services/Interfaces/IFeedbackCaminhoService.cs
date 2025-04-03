using InDoorMappingAPI.Models;

namespace InDoorMappingAPI.Services.Interfaces
{
    public interface IFeedbackCaminhoService
    {
        Task AddAsync(FeedbackCaminho feedback);
        Task<IEnumerable<FeedbackCaminho>> GetAllAsync(long? caminhoId = null);
        Task<double?> GetMediaPorCaminhoAsync(long caminhoId);
    }
}