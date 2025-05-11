using AutoMapper;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.DTOs.PUTs;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Repos.Interfaces;
using InDoorMappingAPI.Services.Interfaces;

namespace InDoorMappingAPI.Services
{
    public class FeedbackForUserService : IFeedbackForUserService
    {
        private readonly IFeedbackForUserRepo _repo;
        private readonly IMapper _mapper;

        public FeedbackForUserService(IFeedbackForUserRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetFeedbackForUserDTO>> GetAllAsync()
        {
            var all = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<GetFeedbackForUserDTO>>(all);
        }

        public async Task<GetFeedbackForUserDTO?> GetByIdAsync(long id)
        {
            var item = await _repo.GetByIdAsync(id);
            return item == null ? null : _mapper.Map<GetFeedbackForUserDTO>(item);
        }

        public async Task AddAsync(PostFeedbackForUserDTO dto)
        {
            var entity = _mapper.Map<FeedbackForUser>(dto);
            await _repo.AddAsync(entity);
        }

        public async Task DeleteAsync(long id)
        {
            await _repo.DeleteAsync(id);
        }
        public async Task UpdateAsync(PutFeedbackForUserDTO dto)
        {
            var entity = await _repo.GetByIdAsync(dto.Id);
            if (entity == null) throw new KeyNotFoundException("Feedback não encontrado.");

            _mapper.Map(dto, entity);
            await _repo.UpdateAsync(entity);
        }
    }

}
