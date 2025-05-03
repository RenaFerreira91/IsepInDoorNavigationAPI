using InDoorMappingAPI.Models;

namespace InDoorMappingAPI.Repos.Interfaces
{
    public interface IFeedbackCaminhoRepo
    {
        Task AddAsync(FeedbackCaminho feedback);
        Task DeleteAsync(long id);
        Task<List<FeedbackCaminho>> GetAllAsync();
        Task<FeedbackCaminho?> GetByIdAsync(long id);
    }
}