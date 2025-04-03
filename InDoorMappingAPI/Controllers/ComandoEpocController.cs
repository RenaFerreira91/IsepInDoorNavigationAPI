using AutoMapper;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InDoorMappingAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/public/[controller]")]
    public class ComandoEpocController : ControllerBase
    {
        private readonly IComandoEpocService _service;
        private readonly IMapper _mapper;

        public ComandoEpocController(IComandoEpocService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComando(PostComandoEpocDTO dto)
        {
            var entity = _mapper.Map<ComandoEpoc>(dto);
            await _service.AddAsync(entity);
            return Ok();
        }

        [HttpGet("GetLast")]
        public async Task<IActionResult> GetUltimoComando(long usuarioId)
        {
            var comando = await _service.GetUltimoComandoAsync(usuarioId);
            if (comando == null)
                return NotFound();

            var result = _mapper.Map<GetComandoEpocDTO>(comando);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComando(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
