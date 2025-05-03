using InDoorMappingAPI.Models;

public interface ILogRepo
{
    Task AddAsync(Log log);
    Task DeleteAsync(long id);
    Task<List<Log>> GetAllAsync();
    Task<Log> GetByIdAsync(long id);
    Task<List<Log>> GetFilteredAsync(string? acao, string? usuarioNome);
}