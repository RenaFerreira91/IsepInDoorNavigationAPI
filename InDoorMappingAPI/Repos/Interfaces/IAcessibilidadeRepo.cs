using InDoorMappingAPI.Models;

namespace InDoorMappingAPI.Repos.Interfaces
{
    public interface IAcessibilidadeRepo
    {
        Task AddAsync(Acessibilidade entity);
        Task DeleteAsync(long id);
        Task<List<Acessibilidade>> GetAllAsync();
        Task<Acessibilidade> GetByIdAsync(long id);
        Task UpdateAsync(Acessibilidade entity);
    }
}