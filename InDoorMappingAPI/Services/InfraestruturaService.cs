
using IndoorMappingAPI.Models;
using IndoorMappingAPI.Repos.Interfaces;
using IndoorMappingAPI.Services.Interfaces;

namespace IndoorMappingAPI.Services
{
    public class InfraestruturaService : IInfraestruturaService
    {
        private readonly IInfraestruturaRepo _repo;

        public InfraestruturaService(IInfraestruturaRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Infraestrutura>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Infraestrutura> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task AddAsync(Infraestrutura entity)
        {
            await _repo.AddAsync(entity);
        }

        public async Task<IEnumerable<Infraestrutura>> GetFilteredAsync(string? tipo, int? piso)
        {
            var all = await _repo.GetAllAsync();
            var query = all.AsQueryable();

            if (!string.IsNullOrWhiteSpace(tipo))
                query = query.Where(i => i.TipoInfraestrutura.Tipo.ToLower().Contains(tipo.ToLower()));

            if (piso!=null)
                query = query.Where(i => i.Piso == piso);

            return query;
        }
    }
}
