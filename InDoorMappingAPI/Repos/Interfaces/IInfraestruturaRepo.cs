using InDoorMappingAPI.Models;

namespace InDoorMappingAPI.Repos.Interfaces
{
    public interface IInfraestruturaRepo
    {
        Task AddAsync(Infraestrutura entity);
        Task<IEnumerable<Infraestrutura>> GetAllAsync();
        Task<Infraestrutura> GetByIdAsync(int id);
    }
}