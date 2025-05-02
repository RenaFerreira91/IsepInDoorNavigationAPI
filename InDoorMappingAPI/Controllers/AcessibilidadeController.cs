using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.DTOs.PUTs;
using InDoorMappingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InDoorMappingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcessibilidadeController : ControllerBase
    {
        private readonly IAcessibilidadeService _service;

        public AcessibilidadeController(IAcessibilidadeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAcessibilidadeDTO>>> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetAcessibilidadeDTO>> GetById(long id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PostAcessibilidadeDTO dto)
        {
            await _service.AddAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, PutAcessibilidadeDTO dto)
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

}
