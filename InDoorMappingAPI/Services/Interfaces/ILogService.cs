using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.Models;

namespace InDoorMappingAPI.Services.Interfaces
{
    public interface ILogService
    {
        Task AddAsync(Log log);
        Task DeleteAsync(long id);
        Task<List<GetLogDTO>> GetAllAsync();
        Task<GetLogDTO> GetByIdAsync(long id);
        Task<List<GetLogDTO>> GetFilteredAsync(string? acao, string? usuarioNome);
    }
}