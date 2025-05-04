using AutoMapper;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InDoorMappingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalizacoesUsuarioController : ControllerBase
    {
        private readonly ILocalizacaoUsuarioService _service;
        private readonly IMapper _mapper;

        public LocalizacoesUsuarioController(ILocalizacaoUsuarioService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetLocalizacaoUsuarioDTO>>> GetAll()
        {
            var localizacoes = await _service.GetAllAsync();
            var dtos = _mapper.Map<List<GetLocalizacaoUsuarioDTO>>(localizacoes);
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<ActionResult> AddOrUpdate(PostLocalizacaoUsuarioDTO dto)
        {
            var localizacao = _mapper.Map<LocalizacaoUsuario>(dto);
            await _service.AddOrUpdateAsync(localizacao);
            return Ok("Localização atualizada com sucesso.");
        }

        [HttpGet("{usuarioId}")]
        public async Task<ActionResult<GetLocalizacaoUsuarioDTO>> GetByUsuarioId(long usuarioId)
        {
            var localizacao = await _service.GetByUsuarioIdAsync(usuarioId);
            if (localizacao == null)
                return NotFound("Nenhuma localização encontrada para este usuário.");

            var dto = _mapper.Map<GetLocalizacaoUsuarioDTO>(localizacao);
            return Ok(dto);
        }
    }

}
