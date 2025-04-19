using InDoorMappingAPI.Models;
using InDoorMappingAPI.Models;

namespace InDoorMappingAPI.Services.Interfaces
{
    public interface IInfraestruturaService
    {
        Task AddAsync(Infraestrutura entity);
        Task<IEnumerable<Infraestrutura>> GetAllAsync();
        Task<Infraestrutura> GetByIdAsync(int id);
        Task<IEnumerable<Infraestrutura>> GetFilteredAsync(string? tipo, int? piso);
    }
}