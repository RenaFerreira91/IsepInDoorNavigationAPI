using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;

namespace InDoorMappingAPI.Services.Interfaces
{
    public interface IFeedbackCaminhoService
    {
        Task AddAsync(PostFeedbackCaminhoDTO dto);
        Task DeleteAsync(long id);
        Task<List<GetFeedbackCaminhoDTO>> GetAllAsync();
        Task<GetFeedbackCaminhoDTO?> GetByIdAsync(long id);
    }
}