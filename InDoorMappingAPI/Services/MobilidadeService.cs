using System.Collections.Generic;
using System.Threading.Tasks;
using IndoorMappingAPI.Models;

public class MobilidadeService : IMobilidadeService
{
    private readonly IMobilidadeRepo _repo;

    public MobilidadeService(IMobilidadeRepo repository)
    {
        _repo = repository;
    }

    public async Task<IEnumerable<Mobilidade>> GetFilteredByTipoAsync(string? tipo)
    {
        var all = await _repo.GetAllAsync();
        var query = all.AsQueryable();

        if (!string.IsNullOrWhiteSpace(tipo))
            query = query.Where(m => m.Tipo.ToLower().Contains(tipo.ToLower()));

        return query;
    }

    public async Task<List<Mobilidade>> GetAllAsync() => await _repo.GetAllAsync();

    public async Task<Mobilidade> GetByIdAsync(long id) => await _repo.GetByIdAsync(id);

    public async Task AddAsync(Mobilidade entity) => await _repo.AddAsync(entity);

    public async Task UpdateAsync(Mobilidade entity) => await _repo.UpdateAsync(entity);

    public async Task DeleteAsync(long id) => await _repo.DeleteAsync(id);
}
