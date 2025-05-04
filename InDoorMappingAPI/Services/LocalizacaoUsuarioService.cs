using InDoorMappingAPI.Models;
using InDoorMappingAPI.Repos.Interfaces;
using InDoorMappingAPI.Services.Interfaces;

namespace InDoorMappingAPI.Services
{
    public class LocalizacaoUsuarioService : ILocalizacaoUsuarioService
    {
        private readonly ILocalizacaoUsuarioRepo _repo;

        public LocalizacaoUsuarioService(ILocalizacaoUsuarioRepo repo)
        {
            _repo = repo;
        }
        public async Task<List<LocalizacaoUsuario>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<LocalizacaoUsuario> GetByUsuarioIdAsync(long usuarioId)
        {
            return await _repo.GetByUsuarioIdAsync(usuarioId);
        }

        public async Task AddOrUpdateAsync(LocalizacaoUsuario localizacao)
        {
            await _repo.AddOrUpdateAsync(localizacao);
        }
    }

}
