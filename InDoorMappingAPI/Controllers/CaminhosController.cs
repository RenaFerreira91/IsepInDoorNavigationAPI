using AutoMapper;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.DTOs.PUTs.InDoorMappingAPI.DTOs.PUTs;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CaminhosController : ControllerBase
{
    private readonly ICaminhoService _service;
    private readonly IMapper _mapper;

    public CaminhosController(ICaminhoService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }


    [HttpGet("melhor-caminho")]
    public async Task<IActionResult> GetMelhorCaminho([FromQuery] long destinoId, [FromQuery] List<long> bloqueados = null)
    {
        bloqueados ??= new List<long>();

        var resultado = await _service.ObterMelhorCaminhoAsync(destinoId, bloqueados);

        if (resultado.InfraestruturasIds == null || !resultado.InfraestruturasIds.Any())
            return NotFound("Nenhum caminho acessível encontrado.");

        return Ok(resultado);
    }
    // CRUD

    [HttpGet]
    public async Task<ActionResult<List<GetCaminhoDTO>>> GetAll()
    {
        var caminhos = await _service.GetAllAsync();
        return Ok(caminhos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetCaminhoDTO>> GetById(long id)
    {
        var caminho = await _service.GetByIdAsync(id);
        if (caminho == null)
            return NotFound();
        return Ok(caminho);
    }

    [HttpPost]
    public async Task<ActionResult> Create(PostCaminhoDTO dto)
    {
        await _service.AddAsync(dto);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(long id, PutCaminhoDTO dto)
    {
        if (id != dto.Id)
            return BadRequest("ID inconsistente.");

        try
        {
            await _service.UpdateAsync(dto);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(long id)
    {
        try
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
