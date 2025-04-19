using IndoorMappingAPI.Models;

namespace IndoorMappingAPI.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task AddAsync(Usuario usuario);
        Task DeleteAsync(long id);
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(long id);
        Task UpdateAsync(Usuario usuario);
    }
}