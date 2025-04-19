using AutoMapper;
using IndoorMappingAPI.DTOs.GETs;
using IndoorMappingAPI.DTOs.POSTs;
using IndoorMappingAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/admin/[controller]")]
public class CaminhosController : ControllerBase
{
    private readonly ICaminhoService _service;
    private readonly IMapper _mapper;

    public CaminhosController(ICaminhoService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<GetCaminhoDTO>>> GetAll()
    {
        var list = await _service.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<GetCaminhoDTO>>(list));
    }

    [AllowAnonymous]
    [HttpGet("GetFiltered")]
    public async Task<IActionResult> GetFiltered(string? origemNome, string? destinoNome, bool? acessivel)
    {
        var caminhos = await _service.GetFilteredAsync(origemNome, destinoNome, acessivel);
        return Ok(_mapper.Map<IEnumerable<GetCaminhoDTO>>(caminhos));
    }

    [Authorize(Roles = "Admin,Editor")]
    [HttpPost]
    public async Task<IActionResult> Create(PostCaminhoDTO dto)
    {
        var entity = _mapper.Map<Caminho>(dto);
        await _service.AddAsync(entity);
        return Created("", _mapper.Map<GetCaminhoDTO>(entity));
    }

    [HttpGet("entre/{origemId}/{destinoId}")]
    public async Task<IActionResult> GetEntreBeacons(int origemId, int destinoId, bool acessivel = false)
    {
        var caminhos = await _service.GetBetweenInfraestruturasAsync(origemId, destinoId, acessivel);
        return Ok(_mapper.Map<IEnumerable<GetCaminhoDTO>>(caminhos));
    }

    [HttpGet("coordenadas")]
    public async Task<IActionResult> GetCaminhosComCoordenadas()
    {
        var caminhos = await _service.GetAllAsync(); // Certifica-te que inclui Origem e Destino
        var resultado = _mapper.Map<IEnumerable<GetCaminhoMapaDTO>>(caminhos);
        return Ok(resultado);
    }
}
