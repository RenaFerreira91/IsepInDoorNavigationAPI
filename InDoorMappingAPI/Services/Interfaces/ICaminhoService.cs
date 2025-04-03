using InDoorMappingAPI.Models;

public interface ICaminhoService
{
    Task<IEnumerable<Caminho>> GetFilteredAsync(string? origemNome, string? destinoNome, bool? isAccessible);
    Task<IEnumerable<Caminho>> GetBetweenBeaconsAsync(long origemBeaconId, long destinoBeaconId, bool isAccessible);
    Task AddAsync(Caminho entity);
    Task DeleteAsync(long id);
    Task<List<Caminho>> GetAllAsync();
    Task<Caminho> GetByIdAsync(long id);
    Task UpdateAsync(Caminho entity);
}