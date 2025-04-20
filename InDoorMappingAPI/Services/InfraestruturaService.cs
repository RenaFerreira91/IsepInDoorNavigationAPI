
using AutoMapper;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Repos.Interfaces;
using InDoorMappingAPI.Services.Interfaces;

namespace InDoorMappingAPI.Services
{
    public class InfraestruturaService : IInfraestruturaService
    {
        private readonly IInfraestruturaRepo _repo;
        private readonly IMapper _mapper;

        public InfraestruturaService(IInfraestruturaRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetInfraestruturaDTO>> GetAllAsync()
        {
            var result = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<GetInfraestruturaDTO>>(result);
        }

        public async Task<GetInfraestruturaDTO> GetByIdAsync(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            return item == null ? null : _mapper.Map<GetInfraestruturaDTO>(item);
        }

        public async Task AddAsync(Infraestrutura entity)
        {
            await _repo.AddAsync(entity);
        }

        public async Task<IEnumerable<GetInfraestruturaDTO>> GetFilteredAsync(string? tipo, int? piso)
        {
            var all = await _repo.GetAllAsync();
            var query = all.AsQueryable();

            if (!string.IsNullOrWhiteSpace(tipo))
                query = query.Where(i => i.TipoInfraestrutura.Tipo.ToLower().Contains(tipo.ToLower()));

            if (piso != null)
                query = query.Where(i => i.Piso == piso);

            return _mapper.Map<IEnumerable<GetInfraestruturaDTO>>(query);
        }
    }
}
