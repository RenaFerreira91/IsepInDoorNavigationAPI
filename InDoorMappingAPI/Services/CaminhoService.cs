using System.Collections.Generic;
using System.Threading.Tasks;
using InDoorMappingAPI.Models;

public class CaminhoService : ICaminhoService
{
    private readonly ICaminhoRepo _repo;

    public CaminhoService(ICaminhoRepo repository)
    {
        _repo = repository;
    }
    public async Task<IEnumerable<Caminho>> GetBetweenInfraestruturasAsync(int origemId, int destinoId, bool isAccessible)
    {
        var caminhos = await _repo.GetAllAsync();
        var query = caminhos.Where(c =>
    c.OrigemId == origemId && c.DestinoId == destinoId
);

        if (isAccessible)
            query = query.Where(c => c.Acessivel);

        return query.OrderBy(c => c.Distancia);
    }

    public async Task<IEnumerable<Caminho>> GetFilteredAsync(string? origemNome, string? destinoNome, bool? isAccessible)
    {
        var caminhos = await _repo.GetAllAsync();
        var query = caminhos.AsQueryable();

        if (!string.IsNullOrWhiteSpace(origemNome))
            query = query.Where(c => c.Origem.Descricao.ToLower().Contains(origemNome.ToLower()));

        if (!string.IsNullOrWhiteSpace(destinoNome))
            query = query.Where(c => c.Destino.Descricao.ToLower().Contains(destinoNome.ToLower()));

        if (isAccessible.HasValue)
            query = query.Where(c => c.Acessivel == isAccessible);

        return query;
    }
    public async Task<List<Caminho>> GetAllAsync() => await _repo.GetAllAsync();

    public async Task<Caminho> GetByIdAsync(long id) => await _repo.GetByIdAsync(id);

    public async Task AddAsync(Caminho entity) => await _repo.AddAsync(entity);

    public async Task UpdateAsync(Caminho entity) => await _repo.UpdateAsync(entity);

    public async Task DeleteAsync(long id) => await _repo.DeleteAsync(id);
}
