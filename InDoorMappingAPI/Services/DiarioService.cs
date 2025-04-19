using InDoorMappingAPI.Models;
using InDoorMappingAPI.Repos.Interfaces;
using InDoorMappingAPI.Services.Interfaces;

namespace InDoorMappingAPI.Services
{
    public class DiarioService : IDiarioService
    {
        private readonly IDiarioRepo _repo;

        public DiarioService(IDiarioRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Diario>> GetFilteredAsync(long? usuarioId, string? tipo, DateTime? inicio, DateTime? fim)
        {
            var query = (await _repo.GetAllAsync()).AsQueryable();

            if (usuarioId.HasValue)
                query = query.Where(d => d.UsuarioId == usuarioId.Value);

            if (!string.IsNullOrEmpty(tipo))
                query = query.Where(d => d.Tipo.ToLower().Contains(tipo.ToLower()));

            if (inicio.HasValue)
                query = query.Where(d => d.DataHora >= inicio.Value);

            if (fim.HasValue)
                query = query.Where(d => d.DataHora <= fim.Value);

            return query;
        }
        public async Task<Diario?> GetLastEntryAsync(long usuarioId)
        {
            var entradas = await _repo.GetAllAsync();
            return entradas
                .Where(d => d.UsuarioId == usuarioId)
                .OrderByDescending(d => d.DataHora)
                .FirstOrDefault();
        }

        public async Task<IEnumerable<Diario>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task AddAsync(Diario entrada)
        {
            await _repo.AddAsync(entrada);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

    }
}
