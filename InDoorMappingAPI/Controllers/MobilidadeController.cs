﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InDoorMappingAPI.Services;
using AutoMapper;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;

namespace InDoorMappingAPI.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class MobilidadesController : ControllerBase
    {
        private readonly IMobilidadeService _service;
        private readonly IMapper _mapper;

        public MobilidadesController(IMobilidadeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetMobilidadeDTO>>> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<GetMobilidadeDTO>>(list));
        }

        [Authorize(Roles = "Admin,Editor")]
        [HttpPost]
        public async Task<IActionResult> Create(PostMobilidadeDTO dto)
        {
            var entity = _mapper.Map<Mobilidade>(dto);
            await _service.AddAsync(entity);
            return Created("", _mapper.Map<GetMobilidadeDTO>(entity));
        }
    }
}