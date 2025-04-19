using InDoorMappingAPI.Models;

namespace InDoorMappingAPI.Services.Interfaces
{
    public interface IComandoEpocService
    {
        Task<IEnumerable<ComandoEpoc>> GetFilteredAsync(long? usuarioId, DateTime? inicio, DateTime? fim);
        Task<ComandoEpoc?> GetUltimoComandoAsync(long usuarioId);
        Task AddAsync(ComandoEpoc comando);
        Task<IEnumerable<ComandoEpoc>> GetAllAsync();
        Task<bool> DeleteAsync(int id);

    }
}