using IndoorMappingAPI.Models;
using IndoorMappingAPI.Repos.Interfaces;
using IndoorMappingAPI.Services.Interfaces;

namespace IndoorMappingAPI.Services
{
    public class ComandoEpocService : IComandoEpocService
    {
        private readonly IComandoEpocRepo _repo;

        public ComandoEpocService(IComandoEpocRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ComandoEpoc>> GetFilteredAsync(long? usuarioId, DateTime? inicio, DateTime? fim)
        {
            var comandos = await _repo.GetAllAsync();
            var query = comandos.AsQueryable();

            if (usuarioId.HasValue)
                query = query.Where(c => c.UsuarioId == usuarioId);

            if (inicio.HasValue)
                query = query.Where(c => c.DataHora >= inicio.Value);

            if (fim.HasValue)
                query = query.Where(c => c.DataHora <= fim.Value);

            return query;
        }

        public async Task<ComandoEpoc?> GetUltimoComandoAsync(long usuarioId)
        {
            var comandos = await _repo.GetAllAsync();
            return comandos
                .Where(c => c.UsuarioId == usuarioId)
                .OrderByDescending(c => c.DataHora)
                .FirstOrDefault();
        }

        public async Task<IEnumerable<ComandoEpoc>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task AddAsync(ComandoEpoc comando)
        {
            await _repo.AddAsync(comando);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
