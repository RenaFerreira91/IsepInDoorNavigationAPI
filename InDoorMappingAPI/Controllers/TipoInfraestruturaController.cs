using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InDoorMappingAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TipoInfraestruturaController : ControllerBase
    {
        private readonly ITipoInfraestruturaService _service;

        public TipoInfraestruturaController(ITipoInfraestruturaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostTipoInfraestruturaDTO dto)
        {
            await _service.AddAsync(dto);
            return Ok("TipoInfraestrutura created successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, GetTipoInfraestruturaDTO dto)
        {
            if (id != dto.Id) return BadRequest("Inconsistent ID.");
            await _service.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}

