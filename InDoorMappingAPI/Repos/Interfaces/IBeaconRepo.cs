using IndoorMappingAPI.Models;

public interface IBeaconRepo
{
    Task AddAsync(Beacon entity);
    Task DeleteAsync(long id);
    Task<List<Beacon>> GetAllAsync();
    Task<Beacon> GetByIdAsync(long id);
    Task UpdateAsync(Beacon entity);
}