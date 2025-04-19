using IndoorMappingAPI.Data;
using IndoorMappingAPI.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class CaminhoRepo : ICaminhoRepo
{
    private readonly DataContext _context;

    public CaminhoRepo(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Caminho>> GetAllAsync()
    {
        return await _context.Caminhos.Include(c => c.Origem)
            .Include(c => c.Destino)
            .Include(c => c.Acessibilidade)
            .ToListAsync();
    }

    public async Task<Caminho> GetByIdAsync(long id)
    {
        return await _context.Caminhos.FirstOrDefaultAsync(e => e.CaminhoId == id);
    }

    public async Task AddAsync(Caminho entity)
    {
        await _context.Caminhos.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Caminho entity)
    {
        _context.Caminhos.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var entity = await _context.Caminhos.FindAsync(id);
        if (entity != null)
        {
            _context.Caminhos.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}