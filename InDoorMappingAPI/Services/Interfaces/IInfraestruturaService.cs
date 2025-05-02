using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.DTOs.PUTs;
using InDoorMappingAPI.Models;

namespace InDoorMappingAPI.Services.Interfaces
{
    public interface IInfraestruturaService
    {
        Task<IEnumerable<GetInfraestruturaDTO>> GetAllAsync();
        Task<GetInfraestruturaDTO> GetByIdAsync(int id);
        Task<IEnumerable<GetInfraestruturaDTO>> GetFilteredAsync(string? tipo, int? piso);
        Task AddAsync(PostInfraestruturaDTO dto);
        Task UpdateAsync(PutInfraestruturaDTO dto);
        Task DeleteAsync(int id);
    }
}