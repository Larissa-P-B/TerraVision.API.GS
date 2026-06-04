using Microsoft.AspNetCore.Mvc;
using TerraVision.API.Services;

namespace TerraVision.API.Controllers
{
    [ApiController]
    [Route("api/devices")]
    public class DeviceController : ControllerBase
    {
        private readonly DeviceSimulationService _service;

        public DeviceController(
            DeviceSimulationService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetDevices()
        {
            return Ok(_service.GetDevices());
        }

        [HttpGet("simulation")]
        public IActionResult RunSimulation()
        {
            return Ok(_service.RunSimulation());
        }
    }
}
