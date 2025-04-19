using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using IndoorMappingAPI.Models;
using IndoorMappingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using IndoorMappingAPI.DTOs.POSTs;
using IndoorMappingAPI.DTOs.GETs;

namespace IndoorMappingAPI.Controllers.Public
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/public/[controller]")]
    public class FeedbackCaminhoController : ControllerBase
    {
        private readonly IFeedbackCaminhoService _service;
        private readonly IMapper _mapper;

        public FeedbackCaminhoController(IFeedbackCaminhoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost("GiveFeedback")]
        public async Task<IActionResult> GiveFeedback(PostFeedbackCaminhoDTO dto)
        {
            var feedback = _mapper.Map<FeedbackCaminho>(dto);
            await _service.AddAsync(feedback);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] long? caminhoId)
        {
            var lista = await _service.GetAllAsync(caminhoId);
            return Ok(_mapper.Map<IEnumerable<GetFeedbackCaminhoDTO>>(lista));
        }

        [HttpGet("media/caminho/{id}")]
        public async Task<IActionResult> GetMedia(long id)
        {
            var media = await _service.GetMediaPorCaminhoAsync(id);
            return media.HasValue ? Ok(media) : NotFound("Sem feedback para esse caminho.");
        }
    }
}
