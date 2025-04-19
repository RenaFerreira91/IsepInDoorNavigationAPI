using InDoorMappingAPI.Models;

namespace InDoorMappingAPI.Repos.Interfaces
{
    public interface IDiarioRepo
    {
        Task AddAsync(Diario entrada);
        Task<IEnumerable<Diario>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
    }
}