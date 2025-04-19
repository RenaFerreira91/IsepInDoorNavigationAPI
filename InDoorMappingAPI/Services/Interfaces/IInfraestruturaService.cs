using IndoorMappingAPI.Models;
using IndoorMappingAPI.Models;

namespace IndoorMappingAPI.Services.Interfaces
{
    public interface IInfraestruturaService
    {
        Task AddAsync(Infraestrutura entity);
        Task<IEnumerable<Infraestrutura>> GetAllAsync();
        Task<Infraestrutura> GetByIdAsync(int id);
        Task<IEnumerable<Infraestrutura>> GetFilteredAsync(string? tipo, int? piso);
    }
}