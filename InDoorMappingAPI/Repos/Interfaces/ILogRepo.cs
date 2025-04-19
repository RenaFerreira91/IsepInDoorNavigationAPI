using InDoorMappingAPI.Models;

public interface ILogRepo
{
    Task AddAsync(Log entity);
    Task DeleteAsync(long id);
    Task<List<Log>> GetAllAsync();
    Task<Log> GetByIdAsync(long id);
    Task UpdateAsync(Log entity);
}