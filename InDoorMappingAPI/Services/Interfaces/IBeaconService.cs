using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.DTOs.PUTs;

namespace InDoorMappingAPI.Services.Interfaces
{
    public interface IBeaconService
    {
        Task<List<GetBeaconDTO>> GetAllAsync();
        Task<GetBeaconDTO> GetByIdAsync(long id);
        Task AddAsync(PostBeaconDTO dto);
        Task UpdateAsync(PutBeaconDTO dto);
        Task DeleteAsync(long id);
    }
}
