using AutoMapper;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Repos.Interfaces;
using InDoorMappingAPI.Services.Interfaces;

namespace InDoorMappingAPI.Services
{
    public class FeedbackCaminhoService : IFeedbackCaminhoService
    {
        private readonly IFeedbackCaminhoRepo _repo;
        private readonly IMapper _mapper;

        public FeedbackCaminhoService(IFeedbackCaminhoRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<GetFeedbackCaminhoDTO>> GetAllAsync()
        {
            var feedbacks = await _repo.GetAllAsync();
            return _mapper.Map<List<GetFeedbackCaminhoDTO>>(feedbacks);
        }

        public async Task<GetFeedbackCaminhoDTO> GetByIdAsync(long id)
        {
            var feedback = await _repo.GetByIdAsync(id);
            return feedback == null ? null : _mapper.Map<GetFeedbackCaminhoDTO>(feedback);
        }

        public async Task AddAsync(PostFeedbackCaminhoDTO dto)
        {
            var entity = _mapper.Map<FeedbackCaminho>(dto);
            entity.Avaliacao = dto.Avaliacao == 0 ? 5 : dto.Avaliacao; // garante default 5
            await _repo.AddAsync(entity);
        }

        public async Task DeleteAsync(long id)
        {
            await _repo.DeleteAsync(id);
        }
    }


}
