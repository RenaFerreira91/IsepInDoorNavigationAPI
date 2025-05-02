using InDoorMappingAPI.Models;

namespace InDoorMappingAPI.Repos.Interfaces
{
    public interface IBeaconRepo
    {
        Task<List<Beacon>> GetAllAsync();
        Task<Beacon> GetByIdAsync(long id);
        Task AddAsync(Beacon beacon);
        Task UpdateAsync(Beacon beacon);
        Task DeleteAsync(long id);
    }
}
