using InDoorMappingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IFeedbackCaminhoRepo
{
    Task<IEnumerable<FeedbackCaminho>> GetAllAsync();
    Task<FeedbackCaminho?> GetByIdAsync(long id);
    Task AddAsync(FeedbackCaminho feedback);
    Task DeleteAsync(long id);
}
