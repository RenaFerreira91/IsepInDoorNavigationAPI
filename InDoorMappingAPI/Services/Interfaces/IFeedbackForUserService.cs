using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;

namespace InDoorMappingAPI.Services.Interfaces
{
    public interface IFeedbackForUserService
    {
        Task AddAsync(PostFeedbackForUserDTO dto);
        Task DeleteAsync(long id);
        Task<IEnumerable<GetFeedbackForUserDTO>> GetAllAsync();
        Task<GetFeedbackForUserDTO?> GetByIdAsync(long id);
    }
}