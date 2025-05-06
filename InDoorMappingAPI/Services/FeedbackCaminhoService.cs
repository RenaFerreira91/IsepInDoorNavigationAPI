using AutoMapper;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

public class FeedbackCaminhoService : IFeedbackCaminhoService
{
    private readonly IFeedbackCaminhoRepo _repo;
    private readonly IMapper _mapper;

    public FeedbackCaminhoService(IFeedbackCaminhoRepo repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetFeedbackCaminhoDTO>> GetAllAsync()
    {
        var feedbacks = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<GetFeedbackCaminhoDTO>>(feedbacks);
    }

    public async Task<GetFeedbackCaminhoDTO?> GetByIdAsync(long id)
    {
        var feedback = await _repo.GetByIdAsync(id);
        return feedback == null ? null : _mapper.Map<GetFeedbackCaminhoDTO>(feedback);
    }

    public async Task AddAsync(PostFeedbackCaminhoDTO dto)
    {
        var entity = _mapper.Map<FeedbackCaminho>(dto);
        await _repo.AddAsync(entity);
    }

    public async Task DeleteAsync(long id)
    {
        await _repo.DeleteAsync(id);
    }
}
