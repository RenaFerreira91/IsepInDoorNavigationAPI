using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.Models;

namespace InDoorMappingAPI.Services.Interfaces
{
    public interface IInfraestruturaService
    {
        Task<GetInfraestruturaDTO> GetByIdAsync(int id);
        Task<IEnumerable<GetInfraestruturaDTO>> GetFilteredAsync(string? tipo, int? piso);
    }
}