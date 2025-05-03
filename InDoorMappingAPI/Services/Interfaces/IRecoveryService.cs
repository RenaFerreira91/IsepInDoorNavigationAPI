using InDoorMappingAPI.Models;

namespace InDoorMappingAPI.Services.Interfaces
{
    public interface IRecoveryService
    {
        Task<string> GenerateRecoveryToken(long userId);
        Task<RecoveryToken> GetValidToken(string token);
        Task InvalidateToken(RecoveryToken recoveryToken);
    }
}