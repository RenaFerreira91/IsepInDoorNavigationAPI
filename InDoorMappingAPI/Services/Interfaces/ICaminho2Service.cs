using InDoorMappingAPI.Models;

namespace InDoorMappingAPI.Services.Interfaces
{
    public interface ICaminho2Service
    {
        Task AddAsync(Caminho2 caminho);
        Task DeleteAsync(long id);
        Task<List<Caminho2>> GetAllAsync();
        Task<Caminho2> GetByIdAsync(long id);
        Task UpdateAsync(Caminho2 caminho);
    }
}