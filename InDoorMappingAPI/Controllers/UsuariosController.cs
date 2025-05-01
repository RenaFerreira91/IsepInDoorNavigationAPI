using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using InDoorMappingAPI.Services.Interfaces;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.PUTs;

namespace InDoorMappingAPI.Controllers
{
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
        public async Task<ActionResult<List<GetUsuarioDTO>>> GetAll()
        {
            try
            {
                var usersDto = await _usuarioService.GetAllAsync();
                return Ok(usersDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro em GetAll: {ex.Message}");
                return StatusCode(500, "Erro interno ao obter os usuários.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetUsuarioDTO>> GetById(long id)
        {
            var usuarioDto = await _usuarioService.GetByIdAsync(id);
            if (usuarioDto == null)
                return NotFound();
            return Ok(usuarioDto);
        }

        //[HttpGet("NovoUsuario")]
        //public async Task<ActionResult> Create(string nome,string email, int tipo, int mobilidadeId = 1)
        //{
        //    var usuario = new Usuario() { Nome = nome, Email = email, TipoUsuarioId = tipo, MobilidadeId = mobilidadeId };
        //    await _usuarioService.AddAsync(usuario);
        //    var readDTO = _mapper.Map<GetUsuarioDTO>(usuario);
        //    return CreatedAtAction(nameof(GetById), new { id = readDTO.UsuarioId }, readDTO);
        //}

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, PutUsuarioDTO dto)
        {
            if (id != dto.UsuarioId)
                return BadRequest("ID inconsistente.");

            try
            {
                await _usuarioService.UpdateAsync(dto);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro em Update: {ex.Message}");
                return StatusCode(500, "Erro interno ao atualizar o usuário.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                await _usuarioService.DeleteAsync(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro em Delete: {ex.Message}");
                return StatusCode(500, "Erro interno ao deletar o usuário.");
            }
        }

    }
}

