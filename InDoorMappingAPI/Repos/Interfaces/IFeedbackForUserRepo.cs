using InDoorMappingAPI.Models;

namespace InDoorMappingAPI.Repos.Interfaces
{
    public interface IFeedbackForUserRepo
    {
        Task AddAsync(FeedbackForUser feedback);
        Task DeleteAsync(long id);
        Task<IEnumerable<FeedbackForUser>> GetAllAsync();
        Task<FeedbackForUser?> GetByIdAsync(long id);
        Task UpdateAsync(FeedbackForUser feedback);
    }
}