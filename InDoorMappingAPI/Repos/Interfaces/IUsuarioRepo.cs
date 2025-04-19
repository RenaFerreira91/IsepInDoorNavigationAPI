using IndoorMappingAPI.Models;

namespace IndoorMappingAPI.Repos.Interfaces
{
    public interface IUsuarioRepo
    {
        Task AddAsync(Usuario usuario);
        Task DeleteAsync(long id);
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(long id);
        Task UpdateAsync(Usuario usuario);
    }
}