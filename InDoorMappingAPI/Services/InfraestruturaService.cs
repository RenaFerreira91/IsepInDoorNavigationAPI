
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Repos.Interfaces;
using InDoorMappingAPI.Services.Interfaces;

namespace InDoorMappingAPI.Services
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

        public async Task<IEnumerable<Infraestrutura>> GetFilteredAsync(string? tipo, string? piso)
        {
            var all = await _repo.GetAllAsync();
            var query = all.AsQueryable();

            if (!string.IsNullOrWhiteSpace(tipo))
                query = query.Where(i => i.TipoInfraestrutura.Tipo.ToLower().Contains(tipo.ToLower()));

            if (!string.IsNullOrWhiteSpace(piso))
                query = query.Where(i => i.Piso.ToLower() == piso.ToLower());

            return query;
        }
    }
}
