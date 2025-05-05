using InDoorMappingAPI.Models;

namespace InDoorMappingAPI.Repos.Interfaces
{
    public interface ITipoInfraestruturaRepo
    {
        Task AddAsync(TipoInfraestrutura entity);
        Task DeleteAsync(long id);
        Task<IEnumerable<TipoInfraestrutura>> GetAllAsync();
        Task<TipoInfraestrutura> GetByIdAsync(long id);
        Task UpdateAsync(TipoInfraestrutura entity);
    }
}