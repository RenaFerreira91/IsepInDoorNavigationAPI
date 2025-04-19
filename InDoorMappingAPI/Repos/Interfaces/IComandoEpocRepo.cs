using IndoorMappingAPI.Models;

namespace IndoorMappingAPI.Repos.Interfaces
{
    public interface IComandoEpocRepo
    {
        Task AddAsync(ComandoEpoc comando);
        Task<IEnumerable<ComandoEpoc>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
    }
}