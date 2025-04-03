using InDoorMappingAPI.Models;

namespace InDoorMappingAPI.Services.Interfaces
{
    public interface IDiarioService
    {
        Task<IEnumerable<Diario>> GetFilteredAsync(long? usuarioId, string? tipo, DateTime? inicio, DateTime? fim);
        Task<Diario?> GetLastEntryAsync(long usuarioId);
        Task AddAsync(Diario entrada);
        Task<IEnumerable<Diario>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
    }
}