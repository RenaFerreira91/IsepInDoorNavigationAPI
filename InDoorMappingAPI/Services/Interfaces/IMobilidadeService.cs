using InDoorMappingAPI.Models;
using System.Threading.Tasks;

public interface IMobilidadeService
{
    Task<IEnumerable<Mobilidade>> GetFilteredByTipoAsync(string? tipo);
    Task AddAsync(Mobilidade entity);
    Task DeleteAsync(long id);
    Task<List<Mobilidade>> GetAllAsync();
    Task<Mobilidade> GetByIdAsync(long id);
    Task UpdateAsync(Mobilidade entity);
}