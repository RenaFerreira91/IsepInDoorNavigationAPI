using InDoorMappingAPI.Data;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.DTOs.PUTs;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InDoorMappingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Caminhos2Controller : ControllerBase
    {
        private readonly ICaminho2Service _service;

        public Caminhos2Controller(ICaminho2Service service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCaminho2DTO>>> GetAll()
        {
            var caminhos = await _service.GetAllAsync();
            return Ok(caminhos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCaminho2DTO>> GetById(long id)
        {
            var caminho = await _service.GetByIdAsync(id);
            if (caminho == null)
                return NotFound();

            return Ok(caminho);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PostCaminho2DTO caminho)
        {
            await _service.AddAsync(caminho);
            return CreatedAtAction(nameof(GetById), new { id = caminho.Id }, caminho);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, PutCaminho2DTO caminho)
        {
            if (id != caminho.Id)
                return BadRequest("ID mismatch.");

            await _service.UpdateAsync(caminho);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }


}
