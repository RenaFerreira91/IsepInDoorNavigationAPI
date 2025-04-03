using AutoMapper;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Admin,Editor,Reader")]
[ApiController]
[Route("api/admin/[controller]")]
public class AcessibilidadeController : ControllerBase
{
    private readonly IAcessibilidadeService _service;
    private readonly IMapper _mapper;

    public AcessibilidadeController(IAcessibilidadeService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetAcessibilidadeDTO>>> GetAll()
    {
        var list = await _service.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<GetAcessibilidadeDTO>>(list));
    }

    [Authorize(Roles = "Admin,Editor")]
    [HttpPost]
    public async Task<IActionResult> Create(PostAcessibilidadeDTO dto)
    {
        var entity = _mapper.Map<Acessibilidade>(dto);
        await _service.AddAsync(entity);
        return Created("", _mapper.Map<GetAcessibilidadeDTO>(entity));
    }
}
