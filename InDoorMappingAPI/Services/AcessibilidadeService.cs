using InDoorMappingAPI.Models;
using InDoorMappingAPI.Repos.Interfaces;
using InDoorMappingAPI.Services.Interfaces;

namespace InDoorMappingAPI.Services
{
    public class AcessibilidadeService : IAcessibilidadeService
    {
        private readonly IAcessibilidadeRepo _repo;

        public AcessibilidadeService(IAcessibilidadeRepo repository)
        {
            _repo = repository;
        }

        public async Task<IEnumerable<Acessibilidade>> GetFilteredByDescricaoAsync(string? descricao)
        {
            var all = await _repo.GetAllAsync();
            var query = all.AsQueryable();

            if (!string.IsNullOrWhiteSpace(descricao))
                query = query.Where(a => a.Descricao.ToLower().Contains(descricao.ToLower()));

            return query;
        }
        public async Task<List<Acessibilidade>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<Acessibilidade> GetByIdAsync(long id) => await _repo.GetByIdAsync(id);

        public async Task AddAsync(Acessibilidade entity) => await _repo.AddAsync(entity);

        public async Task UpdateAsync(Acessibilidade entity) => await _repo.UpdateAsync(entity);

        public async Task DeleteAsync(long id) => await _repo.DeleteAsync(id);
    }
}
