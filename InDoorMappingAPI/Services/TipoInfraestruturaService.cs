using AutoMapper;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Repos.Interfaces;
using InDoorMappingAPI.Services.Interfaces;

namespace InDoorMappingAPI.Services
{
    public class TipoInfraestruturaService : ITipoInfraestruturaService
    {
        private readonly ITipoInfraestruturaRepo _repo;
        private readonly IMapper _mapper;

        public TipoInfraestruturaService(ITipoInfraestruturaRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetTipoInfraestruturaDTO>> GetAllAsync()
        {
            var result = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<GetTipoInfraestruturaDTO>>(result);
        }

        public async Task<GetTipoInfraestruturaDTO> GetByIdAsync(long id)
        {
            var item = await _repo.GetByIdAsync(id);
            return item == null ? null : _mapper.Map<GetTipoInfraestruturaDTO>(item);
        }

        public async Task AddAsync(PostTipoInfraestruturaDTO dto)
        {
            var entity = _mapper.Map<TipoInfraestrutura>(dto);
            await _repo.AddAsync(entity);
        }

        public async Task UpdateAsync(GetTipoInfraestruturaDTO dto)
        {
            var existing = await _repo.GetByIdAsync(dto.Id);
            if (existing == null) throw new InvalidOperationException("TipoInfraestrutura not found.");

            _mapper.Map(dto, existing);
            await _repo.UpdateAsync(existing);
        }

        public async Task DeleteAsync(long id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) throw new InvalidOperationException("TipoInfraestrutura not found.");

            await _repo.DeleteAsync(id);
        }
    }
}
