using IndoorMappingAPI.Models;

namespace IndoorMappingAPI.Services.Interfaces
{
    public interface IAcessibilidadeService
    {
        Task<IEnumerable<Acessibilidade>> GetFilteredByDescricaoAsync(string? descricao);
        Task AddAsync(Acessibilidade entity);
        Task DeleteAsync(long id);
        Task<List<Acessibilidade>> GetAllAsync();
        Task<Acessibilidade> GetByIdAsync(long id);
        Task UpdateAsync(Acessibilidade entity);
    }
}