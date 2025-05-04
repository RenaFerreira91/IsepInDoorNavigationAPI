using InDoorMappingAPI.Models;

namespace InDoorMappingAPI.Repos.Interfaces
{
    public interface ILocalizacaoUsuarioRepo
    {
        Task<List<LocalizacaoUsuario>> GetAllAsync();
        Task AddOrUpdateAsync(LocalizacaoUsuario localizacao);
        Task<LocalizacaoUsuario> GetByUsuarioIdAsync(long usuarioId);
    }
}