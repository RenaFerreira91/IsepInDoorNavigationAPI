using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using InDoorMappingAPI.Models;
using Microsoft.AspNetCore.Authorization;
using InDoorMappingAPI.Services.Interfaces;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;

namespace InDoorMappingAPI.Controllers.Public
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/public/[controller]")]
    public class InfraestruturaController : ControllerBase
    {
        private readonly IInfraestruturaService _service;
        private readonly IMapper _mapper;

        public InfraestruturaController(IInfraestruturaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? tipo, int? piso)
        {
            var result = await _service.GetFilteredAsync(tipo, piso);
            return Ok(_mapper.Map<IEnumerable<GetInfraestruturaDTO>>(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(_mapper.Map<GetInfraestruturaDTO>(item));
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostInfraestruturaDTO dto)
        {
            var entity = _mapper.Map<Infraestrutura>(dto);
            await _service.AddAsync(entity);
            var result = _mapper.Map<GetInfraestruturaDTO>(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.InfraestruturaId }, result);
        }
    }
}
