using AutoMapper;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LogsController : ControllerBase
{
    private readonly ILogService _service;

    public LogsController(ILogService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetLogDTO>>> GetAll()
    {
        var logs = await _service.GetAllAsync();
        return Ok(logs);
    }

    [HttpGet("filter")]
    public async Task<ActionResult<List<GetLogDTO>>> GetFiltered([FromQuery] string? acao, [FromQuery] string? usuarioNome)
    {
        var logs = await _service.GetFilteredAsync(acao, usuarioNome);
        return Ok(logs);
    }

    [HttpPost]
    public async Task<ActionResult> Create(PostLogDTO dto)
    {
        var log = new Log
        {
            UsuarioId = dto.UsuarioId,
            Acao = dto.Acao,
            DataHora = DateTime.UtcNow
        };

        await _service.AddAsync(log);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(long id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
