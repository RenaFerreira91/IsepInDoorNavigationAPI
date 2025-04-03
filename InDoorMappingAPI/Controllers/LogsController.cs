using AutoMapper;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Admin,Editor,Reader")]
[ApiController]
[Route("api/admin/[controller]")]
public class LogsController : ControllerBase
{
    private readonly ILogService _service;
    private readonly IMapper _mapper;

    public LogsController(ILogService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetLogDTO>>> GetAll()
    {
        var list = await _service.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<GetLogDTO>>(list));
    }

    [Authorize(Roles = "Admin,Editor")]
    [HttpPost]
    public async Task<IActionResult> Create(PostLogDTO dto)
    {
        var entity = _mapper.Map<Log>(dto);
        await _service.AddAsync(entity);
        return Created("", _mapper.Map<GetLogDTO>(entity));
    }
}
