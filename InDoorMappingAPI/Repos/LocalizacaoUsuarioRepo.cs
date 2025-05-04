using InDoorMappingAPI.Data;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InDoorMappingAPI.Repos
{
    public class LocalizacaoUsuarioRepo : ILocalizacaoUsuarioRepo
    {
        private readonly DataContext _context;

        public LocalizacaoUsuarioRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<LocalizacaoUsuario> GetByUsuarioIdAsync(long usuarioId)
        {
            return await _context.LocalizacoesUsuario.FindAsync(usuarioId);
        }
        public async Task<List<LocalizacaoUsuario>> GetAllAsync()
        {
            return await _context.LocalizacoesUsuario.ToListAsync();
        }


        public async Task AddOrUpdateAsync(LocalizacaoUsuario localizacao)
        {
            var existing = await _context.LocalizacoesUsuario.FindAsync(localizacao.UsuarioId);
            if (existing == null)
            {
                await _context.LocalizacoesUsuario.AddAsync(localizacao);
            }
            else
            {
                existing.Latitude = localizacao.Latitude;
                existing.Longitude = localizacao.Longitude;
                existing.DataHora = DateTime.UtcNow;
            }
            await _context.SaveChangesAsync();
        }
    }


}
