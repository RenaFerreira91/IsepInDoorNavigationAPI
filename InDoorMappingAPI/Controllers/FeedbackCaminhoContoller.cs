using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.DTOs.GETs;

namespace InDoorMappingAPI.Controllers.Public
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/public/[controller]")]
    public class FeedbackCaminhosController : ControllerBase
    {
        private readonly IFeedbackCaminhoService _service;

        public FeedbackCaminhosController(IFeedbackCaminhoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetFeedbackCaminhoDTO>>> GetAll()
        {
            var feedbacks = await _service.GetAllAsync();
            return Ok(feedbacks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetFeedbackCaminhoDTO>> GetById(long id)
        {
            var feedback = await _service.GetByIdAsync(id);
            if (feedback == null)
                return NotFound();

            return Ok(feedback);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PostFeedbackCaminhoDTO dto)
        {
            if (dto.Avaliacao < 1 || dto.Avaliacao > 5)
                return BadRequest("Avaliacao must be between 1 and 5.");

            await _service.AddAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
