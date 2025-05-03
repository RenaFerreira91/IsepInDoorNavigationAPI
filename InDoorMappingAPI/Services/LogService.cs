using AutoMapper;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Services.Interfaces;

namespace InDoorMappingAPI.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepo _repo;
        private readonly IMapper _mapper;

        public LogService(ILogRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<GetLogDTO>> GetAllAsync()
        {
            var logs = await _repo.GetAllAsync();
            return _mapper.Map<List<GetLogDTO>>(logs);
        }

        public async Task<List<GetLogDTO>> GetFilteredAsync(string? acao, string? usuarioNome)
        {
            var logs = await _repo.GetFilteredAsync(acao, usuarioNome);
            return _mapper.Map<List<GetLogDTO>>(logs);
        }

        public async Task<GetLogDTO> GetByIdAsync(long id)
        {
            var log = await _repo.GetByIdAsync(id);
            return _mapper.Map<GetLogDTO>(log);
        }

        public async Task AddAsync(Log log)
        {
            await _repo.AddAsync(log);
        }

        public async Task DeleteAsync(long id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}

