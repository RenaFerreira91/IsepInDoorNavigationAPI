using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.DTOs.PUTs;

namespace InDoorMappingAPI.Services.Interfaces
{
    public interface IAcessibilidadeService
    {
        Task AddAsync(PostAcessibilidadeDTO dto);
        Task DeleteAsync(long id);
        Task<List<GetAcessibilidadeDTO>> GetAllAsync();
        Task<GetAcessibilidadeDTO> GetByIdAsync(long id);
        Task UpdateAsync(PutAcessibilidadeDTO dto);
    }
}