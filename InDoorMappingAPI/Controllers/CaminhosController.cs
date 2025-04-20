using AutoMapper;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using Microsoft.AspNetCore.Authorization;
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
}
