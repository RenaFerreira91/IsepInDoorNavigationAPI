using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.DTOs.GETs;

namespace InDoorMappingAPI.Controllers.Public
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackCaminhosController : ControllerBase
    {
        private readonly IFeedbackCaminhoService _service;

        public FeedbackCaminhosController(IFeedbackCaminhoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetFeedbackCaminhoDTO>>> GetAll()
        {
            var feedbacks = await _service.GetAllAsync();
            return Ok(feedbacks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetFeedbackCaminhoDTO>> GetById(long id)
        {
            var feedback = await _service.GetByIdAsync(id);
            if (feedback == null) return NotFound("Feedback not found.");
            return Ok(feedback);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PostFeedbackCaminhoDTO dto)
        {
            await _service.AddAsync(dto);
            return Ok("Feedback created successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _service.DeleteAsync(id);
            return Ok("Feedback deleted successfully.");
        }
    }

}
