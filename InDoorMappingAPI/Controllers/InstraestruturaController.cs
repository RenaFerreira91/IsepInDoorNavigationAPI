using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using InDoorMappingAPI.Models;
using Microsoft.AspNetCore.Authorization;
using InDoorMappingAPI.Services.Interfaces;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.DTOs.PUTs;

namespace InDoorMappingAPI.Controllers.Public
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class InfraestruturaController : ControllerBase
    {
        private readonly IInfraestruturaService _service;

        public InfraestruturaController(IInfraestruturaService service, IMapper mapper)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? tipo, int? piso)
        {
            var result = await _service.GetFilteredAsync(tipo, piso);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();
            return Ok(dto);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PutInfraestruturaDTO dto)
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
        public async Task<ActionResult> Delete(int id)
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
}
