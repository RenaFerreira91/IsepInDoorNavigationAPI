using InDoorMappingAPI.Models;
using InDoorMappingAPI.Repos.Interfaces;
using InDoorMappingAPI.Services.Interfaces;

namespace InDoorMappingAPI.Services
{
    public class RecoveryService : IRecoveryService
    {
        private readonly IRecoveryTokenRepo _repo;

        public RecoveryService(IRecoveryTokenRepo repo)
        {
            _repo = repo;
        }

        public async Task<string> GenerateRecoveryToken(long userId)
        {
            var token = Guid.NewGuid().ToString();
            var expiration = DateTime.UtcNow.AddHours(1);

            var recovery = new RecoveryToken
            {
                UserId = userId,
                Token = token,
                Expiration = expiration
            };

            await _repo.AddAsync(recovery);
            return token;
        }

        public async Task<RecoveryToken?> GetValidToken(string token)
        {
            return await _repo.GetValidTokenAsync(token);
        }

        public async Task InvalidateToken(RecoveryToken recoveryToken)
        {
            await _repo.DeleteAsync(recoveryToken);
        }

        
    }
}
