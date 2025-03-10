using Application.DTO.PowerUnit;
using Application.Inrefaces;
using Asp.Versioning;
using Domain.DTO;
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

        [HttpPost]
        [ProducesResponseType(typeof(Station), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateStationRequest request)
        {
            var result = await _repository.CreateAsync(request);
            return StatusCode(StatusCodes.Status201Created, result);
        }

        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<Station>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] FilteringStationRequest request)
        {
            var result = await _repository.GetAsync(request);
            return Ok(result);
        }
    }
}
