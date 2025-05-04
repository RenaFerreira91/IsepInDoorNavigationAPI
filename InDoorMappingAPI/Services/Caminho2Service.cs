using InDoorMappingAPI.Models;
using InDoorMappingAPI.Repos.Interfaces;
using InDoorMappingAPI.Services.Interfaces;

namespace InDoorMappingAPI.Services
{
    public class Caminho2Service : ICaminho2Service
    {
        private readonly ICaminho2Repo _repo;

        public Caminho2Service(ICaminho2Repo repo)
        {
            _repo = repo;
        }

        public async Task<List<Caminho2>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<Caminho2> GetByIdAsync(long id) => await _repo.GetByIdAsync(id);

        public async Task AddAsync(Caminho2 caminho) => await _repo.AddAsync(caminho);

        public async Task UpdateAsync(Caminho2 caminho) => await _repo.UpdateAsync(caminho);

        public async Task DeleteAsync(long id) => await _repo.DeleteAsync(id);
    }

}
