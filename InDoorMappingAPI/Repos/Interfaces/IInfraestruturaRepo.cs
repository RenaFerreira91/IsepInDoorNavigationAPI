using IndoorMappingAPI.Models;

namespace IndoorMappingAPI.Repos.Interfaces
{
    public interface IInfraestruturaRepo
    {
        Task AddAsync(Infraestrutura entity);
        Task<IEnumerable<Infraestrutura>> GetAllAsync();
        Task<Infraestrutura> GetByIdAsync(int id);
    }
}