﻿using Application.DTO.PowerUnit;
using Application.DTO.Station;
using Application.Inrefaces;
using Asp.Versioning;
using Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController, ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/power-unit")]
    [Authorize]
    public class PowerUnitController : ControllerBase
    {
        private readonly IPowerUnitRepository _repository;

        public PowerUnitController(IPowerUnitRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PowerUnitResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreatePowerUnitRequest request)
        {
            var result = await _repository.CreateAsync(request);
            return StatusCode(StatusCodes.Status201Created, result);
        }

        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(PowerUnitResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _repository.GetAsync(id);
            return Ok(result);
        }

        
        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<PowerUnitResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] FilteringPowerUnitRequest request)
        {
            var result = await _repository.GetAsync(request);
            return Ok(result);
        }

        [HttpPut("{id:long}")]
        [ProducesResponseType(typeof(PowerUnitResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(long id, [FromBody] UpdatePowerUnitRequest request)
        {
            var result = await _repository.UpdateAsync(id, request);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpDelete("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(long id)
        {
            await _repository.DeleteAsync(id);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
