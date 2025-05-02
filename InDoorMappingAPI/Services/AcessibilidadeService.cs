using AutoMapper;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.DTOs.PUTs;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Repos.Interfaces;
using InDoorMappingAPI.Services.Interfaces;

namespace InDoorMappingAPI.Services
{
    public class AcessibilidadeService : IAcessibilidadeService
    {
        private readonly IAcessibilidadeRepo _repo;
        private readonly IMapper _mapper;

        public AcessibilidadeService(IAcessibilidadeRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<GetAcessibilidadeDTO>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();
            return _mapper.Map<List<GetAcessibilidadeDTO>>(entities);
        }

        public async Task<GetAcessibilidadeDTO> GetByIdAsync(long id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return _mapper.Map<GetAcessibilidadeDTO>(entity);
        }

        public async Task AddAsync(PostAcessibilidadeDTO dto)
        {
            var entity = _mapper.Map<Acessibilidade>(dto);
            await _repo.AddAsync(entity);
        }

        public async Task UpdateAsync(PutAcessibilidadeDTO dto)
        {
            var existing = await _repo.GetByIdAsync(dto.Id);
            if (existing == null) throw new InvalidOperationException("Acessibilidade não encontrada.");

            _mapper.Map(dto, existing);
            await _repo.UpdateAsync(existing);
        }

        public async Task DeleteAsync(long id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) throw new InvalidOperationException("Acessibilidade não encontrada.");

            await _repo.DeleteAsync(id);
        }
    }

}
