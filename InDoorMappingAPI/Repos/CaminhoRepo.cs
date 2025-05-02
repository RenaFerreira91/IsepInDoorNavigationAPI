using InDoorMappingAPI.Data;
using Microsoft.EntityFrameworkCore;

public class CaminhoRepo : ICaminhoRepo
{
    private readonly DataContext _context;

    public CaminhoRepo(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Caminho>> GetCaminhoBidirectional(int origemId, int destinoId)
    {
        return await _context.Caminhos
            .Where(c =>
                (c.OrigemId == origemId && c.DestinoId == destinoId) ||
                (c.OrigemId == destinoId && c.DestinoId == origemId)) // bidirecional
            .Include(c => c.Acessibilidade)
            .ToListAsync();
    }

    public async Task<List<Caminho>> GetAllAsync()
    {
        return await _context.Caminhos
            .Include(c => c.Acessibilidade)
            .ToListAsync();
    }

    public async Task<Caminho> GetByIdAsync(long id)
    {
        return await _context.Caminhos
            .Include(c => c.Acessibilidade)
            .FirstOrDefaultAsync(c => c.Id == id);

    }

    public async Task AddAsync(Caminho caminho)
    {
        await _context.Caminhos.AddAsync(caminho);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Caminho caminho)
    {
        _context.Caminhos.Update(caminho);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var caminho = await _context.Caminhos.FindAsync(id);
        if (caminho != null)
        {
            _context.Caminhos.Remove(caminho);
            await _context.SaveChangesAsync();
        }
    }

}