using InDoorMappingAPI.Models;

namespace InDoorMappingAPI.Services.Interfaces
{
    public interface ILocalizacaoUsuarioService
    {
        Task<List<LocalizacaoUsuario>> GetAllAsync();
        Task AddOrUpdateAsync(LocalizacaoUsuario localizacao);
        Task<LocalizacaoUsuario> GetByUsuarioIdAsync(long usuarioId);
    }
}