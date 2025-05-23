﻿using Microsoft.AspNetCore.Mvc;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.DTOs.PUTs;
using InDoorMappingAPI.Services.Interfaces;

namespace InDoorMappingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BeaconsController : ControllerBase
    {
        private readonly IBeaconService _beaconService;

        public BeaconsController(IBeaconService beaconService)
        {
            _beaconService = beaconService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetBeaconDTO>>> GetAll()
        {
            var beacons = await _beaconService.GetAllAsync();
            return Ok(beacons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetBeaconDTO>> GetById(long id)
        {
            var beacon = await _beaconService.GetByIdAsync(id);
            if (beacon == null)
                return NotFound();
            return Ok(beacon);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PostBeaconDTO dto)
        {
            await _beaconService.AddAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, PutBeaconDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID inconsistente.");

            try
            {
                await _beaconService.UpdateAsync(dto);
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
                await _beaconService.DeleteAsync(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
