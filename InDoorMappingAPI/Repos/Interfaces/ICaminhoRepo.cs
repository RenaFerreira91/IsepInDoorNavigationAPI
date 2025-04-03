using InDoorMappingAPI.Models;

public interface ICaminhoRepo
{
    Task AddAsync(Caminho entity);
    Task DeleteAsync(long id);
    Task<List<Caminho>> GetAllAsync();
    Task<Caminho> GetByIdAsync(long id);
    Task UpdateAsync(Caminho entity);
}