using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.PUTs;
using InDoorMappingAPI.Models;

namespace InDoorMappingAPI.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task AddAsync(Usuario usuario);
        Task DeleteAsync(long id);
        Task<List<GetUsuarioDTO>> GetAllAsync();
        Task<GetUsuarioDTO> GetByIdAsync(long id);
        Task UpdateAsync(PutUsuarioDTO dto);
    }
}