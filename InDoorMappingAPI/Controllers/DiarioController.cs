using AutoMapper;
using IndoorMappingAPI.DTOs.GETs;
using IndoorMappingAPI.DTOs.POSTs;
using IndoorMappingAPI.Models;
using IndoorMappingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IndoorMappingAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/public/[controller]")]
    public class DiarioController : ControllerBase
    {
        private readonly IDiarioService _service;
        private readonly IMapper _mapper;

        public DiarioController(IDiarioService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntry(PostDiarioDTO dto)
        {
            var entity = _mapper.Map<Diario>(dto);
            await _service.AddAsync(entity);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetEntry(long? usuarioId, string? tipo, DateTime? de, DateTime? ate)
        {
            var result = await _service.GetFilteredAsync(usuarioId, tipo, de, ate);
            return Ok(_mapper.Map<IEnumerable<GetDiarioDto>>(result));
        }

        [HttpGet("LastEntry")]
        public async Task<IActionResult> GetLastEntry([FromQuery] long usuarioId)
        {
            var entrada = await _service.GetLastEntryAsync(usuarioId);
            if (entrada == null)
                return NotFound();

            return Ok(_mapper.Map<GetDiarioDto>(entrada));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
