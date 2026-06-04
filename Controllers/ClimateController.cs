using Microsoft.AspNetCore.Mvc;
using TerraVision.API.Exceptions;
using TerraVision.API.Services.Interfaces;

namespace TerraVision.API.Controllers
{
    [ApiController]
    [Route("api/climate")]
    public class ClimateController : ControllerBase
    {
        private readonly IClimateService _service;

        public ClimateController(IClimateService service)
        {
            _service = service;
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetClimate(string city)
        {
            var result =
                await _service.GetClimateAsync(city);

            return Ok(result);
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetHistory()
        {
            var result = await _service.GetHistoryAsync();

            return Ok(result);
        }

        [HttpGet("history/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid guid))
            {
                throw new InvalidGuidException(id);
            }

            var result = await _service.GetByIdAsync(guid);

            return Ok(result);
        }

        [HttpGet("stats")]
        public async Task<IActionResult> GetStats()
        {
            var result =
                await _service.GetStatsAsync();

            return Ok(result);
        }
    }
}
