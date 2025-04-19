using IndoorMappingAPI.Models;
using IndoorMappingAPI.Repos.Interfaces;
using IndoorMappingAPI.Services.Interfaces;

namespace IndoorMappingAPI.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepo _repo;

        public UsuarioService(IUsuarioRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Usuario>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<Usuario> GetByIdAsync(long id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task AddAsync(Usuario usuario) => await _repo.AddAsync(usuario);

        public async Task UpdateAsync(Usuario usuario) => await _repo.UpdateAsync(usuario);

        public async Task DeleteAsync(long id) => await _repo.DeleteAsync(id);
    }
}
