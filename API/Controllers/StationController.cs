using Application.DTO.PowerUnit;
using Application.DTO.Station;
using Application.Inrefaces;
using Asp.Versioning;
using Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController, ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/station")]
    public class StationController : ControllerBase
    {
        private readonly IStationRepository _repository;

        public StationController(IStationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(StationResponse), StatusCodes.Status200OK)]
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
        [ProducesResponseType(typeof(IEnumerable<StationResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] FilteringStationRequest request)
        {
            var result = await _repository.GetAsync(request);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(StationResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateStationRequest request)
        {
            var result = await _repository.CreateAsync(request);
            return StatusCode(StatusCodes.Status201Created, result);
        }

        [HttpPut("{id:long}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(StationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateStationRequest request)
        {
            var result = await _repository.UpdateAsync(id, request);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpDelete("{id:long}")]
        [Authorize(Roles = "Admin")]
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
