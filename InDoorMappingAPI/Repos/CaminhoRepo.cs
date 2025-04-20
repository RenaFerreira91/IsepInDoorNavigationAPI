using InDoorMappingAPI.Data;
using InDoorMappingAPI.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InDoorMappingAPI.DTOs.GETs;

public class CaminhoRepo : ICaminhoRepo
{
    private readonly DataContext _context;

    public CaminhoRepo(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Caminho>> ObterCaminhos(int origemId, int destinoId)
    {
        return await _context.Caminhos
            .Where(c =>
                (c.OrigemId == origemId && c.DestinoId == destinoId) ||
                (c.OrigemId == destinoId && c.DestinoId == origemId)) // bidirecional
            .Include(c => c.Acessibilidade)
            .ToListAsync();
    }

    public async Task<List<Caminho>> ObterTodosCaminhosAcessiveisAsync()
    {
        var result = await _context.Caminhos
            //.Where(c => c.Acessivel)
            .ToListAsync();
        return result;
    }
}