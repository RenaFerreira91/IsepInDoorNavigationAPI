using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;

namespace InDoorMappingAPI.Services.Interfaces
{
    public interface ITipoInfraestruturaService
    {
        Task AddAsync(PostTipoInfraestruturaDTO dto);
        Task DeleteAsync(long id);
        Task<IEnumerable<GetTipoInfraestruturaDTO>> GetAllAsync();
        Task<GetTipoInfraestruturaDTO> GetByIdAsync(long id);
        Task UpdateAsync(GetTipoInfraestruturaDTO dto);
    }
}