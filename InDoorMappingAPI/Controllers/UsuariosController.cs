using Microsoft.AspNetCore.Mvc;
using InDoorMappingAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using InDoorMappingAPI.Services.Interfaces;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;

namespace InDoorMappingAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUsuarioDTO>>> GetAll()
        {
            var usuarios = await _usuarioService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<GetUsuarioDTO>>(usuarios));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetUsuarioDTO>> GetById(long id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);
            if (usuario == null)
                return NotFound();
            return Ok(_mapper.Map<GetUsuarioDTO>(usuario));
        }

        [HttpPost]
        public async Task<ActionResult> Create(PostUsuarioDTO dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);
            await _usuarioService.AddAsync(usuario);
            var readDTO = _mapper.Map<GetUsuarioDTO>(usuario);
            return CreatedAtAction(nameof(GetById), new { id = readDTO.UsuarioId }, readDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, PutUsuarioDTO dto)
        {
            if (id.ToString() != dto.UsuarioId)
                return BadRequest("ID inconsistente.");

            var existing = await _usuarioService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            _mapper.Map(dto, existing); // Atualiza apenas os campos do DTO
            await _usuarioService.UpdateAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var existing = await _usuarioService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _usuarioService.DeleteAsync(id);
            return NoContent();
        }
    }
}

