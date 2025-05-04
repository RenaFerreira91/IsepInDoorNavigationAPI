using AutoMapper;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.DTOs.PUTs;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Repos.Interfaces;
using InDoorMappingAPI.Services.Interfaces;

namespace InDoorMappingAPI.Services
{
    public class Caminho2Service : ICaminho2Service
    {
        private readonly ICaminho2Repo _repo;
        private readonly IMapper _mapper;

        public Caminho2Service(ICaminho2Repo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<GetCaminho2DTO>> GetAllAsync()
        {
            var caminhos = await _repo.GetAllAsync();
            return _mapper.Map<List<GetCaminho2DTO>>(caminhos);
        }

        public async Task<GetCaminho2DTO> GetByIdAsync(long id)
        {
            var caminho = await _repo.GetByIdAsync(id);
            return _mapper.Map<GetCaminho2DTO>(caminho);
        }

        public async Task AddAsync(PostCaminho2DTO dto)
        {
            var caminho = _mapper.Map<Caminho2>(dto);
            await _repo.AddAsync(caminho);
        }

        public async Task UpdateAsync(PutCaminho2DTO dto)
        {
            var existing = await _repo.GetByIdAsync(dto.Id);
            if (existing == null)
                throw new InvalidOperationException("Caminho não encontrado.");

            _mapper.Map(dto, existing);  // atualiza apenas os campos do DTO sobre a entidade existente
            await _repo.UpdateAsync(existing);
        }

        public async Task DeleteAsync(long id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                throw new InvalidOperationException("Caminho não encontrado.");

            await _repo.DeleteAsync(id);
        }
    }
}
