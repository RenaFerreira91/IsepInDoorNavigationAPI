using IndoorMappingAPI.Models;

public interface IBeaconService
{
    Task<IEnumerable<Beacon>> GetFilteredAsync(string? nome, double? lat, double? lng);
    Task AddAsync(Beacon entity);
    Task DeleteAsync(long id);
    Task<List<Beacon>> GetAllAsync();
    Task<Beacon> GetByIdAsync(long id);
    Task UpdateAsync(Beacon entity);
}