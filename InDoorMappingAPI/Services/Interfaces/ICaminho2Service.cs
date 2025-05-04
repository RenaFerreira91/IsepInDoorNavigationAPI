using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.DTOs.PUTs;

namespace InDoorMappingAPI.Services.Interfaces
{
    public interface ICaminho2Service
    {
        Task AddAsync(PostCaminho2DTO dto);
        Task DeleteAsync(long id);
        Task<List<GetCaminho2DTO>> GetAllAsync();
        Task<GetCaminho2DTO> GetByIdAsync(long id);
        Task UpdateAsync(PutCaminho2DTO dto);
    }
}