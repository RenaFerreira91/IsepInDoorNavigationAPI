using IndoorMappingAPI.Models;

public interface ILogService
{

    Task<IEnumerable<Log>> GetFilteredAsync(string? acao, string? usuarioNome);

    Task AddAsync(Log entity);
    Task DeleteAsync(long id);
    Task<List<Log>> GetAllAsync();
    Task<Log> GetByIdAsync(long id);
    Task UpdateAsync(Log entity);
}