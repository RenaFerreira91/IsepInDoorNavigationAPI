using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;

namespace InDoorMappingAPI.Controllers.Admin
{
    [Authorize(Roles = "Admin,Editor,Reader")]
    [ApiController]
    [Route("api/admin/[controller]")]
    public class BeaconsController : ControllerBase
    {
        private readonly IBeaconService _service;
        private readonly IMapper _mapper;

        public BeaconsController(IBeaconService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<GetBeaconDTO>>> GetAll()
        {
            var entities = await _service.GetAllAsync();
            var result = _mapper.Map<IEnumerable<GetBeaconDTO>>(entities);
            return Ok(result);
        }

        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<GetBeaconDTO>>> Get(string? nome, double? lat, double? lng)
        {
            var filtered = await _service.GetFilteredAsync(nome, lat, lng);
            return Ok(_mapper.Map<IEnumerable<GetBeaconDTO>>(filtered));
        }

        [Authorize(Roles = "Admin,Editor")]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(PostBeaconDTO dto)
        {
            var entity = _mapper.Map<Beacon>(dto);
            await _service.AddAsync(entity);
            return CreatedAtAction(nameof(GetAll), new { id = entity.BeaconId }, _mapper.Map<GetBeaconDTO>(entity));
        }
    }
}
