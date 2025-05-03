using InDoorMappingAPI.Models;

namespace InDoorMappingAPI.Repos.Interfaces
{
    public interface IRecoveryTokenRepo
    {
        Task AddAsync(RecoveryToken token);
        Task DeleteAsync(RecoveryToken token);
        Task<RecoveryToken?> GetValidTokenAsync(string token);
    }
}