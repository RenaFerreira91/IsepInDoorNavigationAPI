using System.Threading.Tasks;
using InDoorMappingAPI.Models;

public class LogService : ILogService
{
    private readonly ILogRepo _repo;

    public LogService(ILogRepo repository)
    {
        _repo = repository;
    }

    public async Task<IEnumerable<Log>> GetFilteredAsync(string? acao, string? usuarioNome)
    {
        var all = await _repo.GetAllAsync();
        var query = all.AsQueryable();

        if (!string.IsNullOrWhiteSpace(acao))
            query = query.Where(l => l.Acao.ToLower().Contains(acao.ToLower()));

        if (!string.IsNullOrWhiteSpace(usuarioNome))
            query = query.Where(l => l.Usuario != null && l.Usuario.Nome.ToLower().Contains(usuarioNome.ToLower()));

        return query;
    }


    public async Task<List<Log>> GetAllAsync() => await _repo.GetAllAsync();

    public async Task<Log> GetByIdAsync(long id) => await _repo.GetByIdAsync(id);

    public async Task AddAsync(Log entity) => await _repo.AddAsync(entity);

    public async Task UpdateAsync(Log entity) => await _repo.UpdateAsync(entity);

    public async Task DeleteAsync(long id) => await _repo.DeleteAsync(id);
}
