using InDoorMappingAPI.Models;

public interface IMobilidadeRepo
{
    Task AddAsync(Mobilidade entity);
    Task DeleteAsync(long id);
    Task<List<Mobilidade>> GetAllAsync();
    Task<Mobilidade> GetByIdAsync(long id);
    Task UpdateAsync(Mobilidade entity);
}