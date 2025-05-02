using InDoorMappingAPI.Models;
using System.Threading.Tasks;

public interface ICaminhoRepo
{
    Task<List<Caminho>> GetCaminhoBidirectional(int origemId, int destinoId);
    Task<List<Caminho>> GetAllAsync();
    Task<Caminho> GetByIdAsync(long id);
    Task AddAsync(Caminho caminho);
    Task UpdateAsync(Caminho caminho);
    Task DeleteAsync(long id);


}