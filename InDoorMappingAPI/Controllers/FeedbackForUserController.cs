using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InDoorMappingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackForUserController : ControllerBase
    {
        private readonly IFeedbackForUserService _service;

        public FeedbackForUserController(IFeedbackForUserService service)
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
            return dto == null ? NotFound() : Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostFeedbackForUserDTO dto)
        {
            await _service.AddAsync(dto);
            return Ok("FeedbackForUser created.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }

}
