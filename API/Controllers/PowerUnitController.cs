using Application.DTO.PowerUnit;
using Application.Inrefaces;
using Asp.Versioning;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController, ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/power-unit")]
    public class PowerUnitController : ControllerBase
    {
        private readonly IPowerUnitRepository _repository;

        public PowerUnitController(IPowerUnitRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PowerUnit), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreatePowerUnitRequest request)
        {
            var result = await _repository.CreateAsync(request);
            return StatusCode(StatusCodes.Status201Created, result);
        }

        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<PowerUnit>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] FilteringPowerUnitRequest request)
        {
            var result = await _repository.GetAsync(request);
            return Ok(result);
        }
    }
}
