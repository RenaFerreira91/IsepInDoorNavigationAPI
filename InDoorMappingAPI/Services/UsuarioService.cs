using AutoMapper;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.DTOs.PUTs;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Repos;
using InDoorMappingAPI.Repos.Interfaces;
using InDoorMappingAPI.Services.Interfaces;

namespace InDoorMappingAPI.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepo _repo;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<GetUsuarioDTO>> GetAllAsync()
        {
            var usuarios = await _repo.GetAllAsync();
            return _mapper.Map<List<GetUsuarioDTO>>(usuarios);
        }
        public async Task<GetUsuarioDTO> GetByIdAsync(long id)
        {
            var usuario = await _repo.GetByIdAsync(id);
            return _mapper.Map<GetUsuarioDTO>(usuario);
        }

        public async Task AddAsync(Usuario usuario) => await _repo.AddAsync(usuario);

        public async Task UpdateAsync(PutUsuarioDTO dto)
        {
            var existing = await _repo.GetByIdAsync(dto.UsuarioId);
            if (existing == null) throw new InvalidOperationException("Usuário não encontrado.");

            existing.Nome = dto.Nome;
            existing.Email = dto.Email;
            existing.TipoUsuarioId = dto.TipoUsuarioId;
            existing.MobilidadeId = dto.MobilidadeId;

            await _repo.UpdateAsync(existing);
        }

        public async Task DeleteAsync(long id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) throw new InvalidOperationException("Usuário não encontrado.");

            await _repo.DeleteAsync(id);
        }
       

    }
}
