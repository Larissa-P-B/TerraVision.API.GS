using Microsoft.AspNetCore.Mvc;
using TerraVision.API.Services.Interfaces;

namespace TerraVision.API.Controllers
{
    [ApiController]
    [Route("api/alerts")]
    public class AlertController : ControllerBase
    {
        private readonly IAlertService _service;

        public AlertController(
            IAlertService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAlerts()
        {
            var alerts = _service.GetAlerts();

            return Ok(alerts);
        }

        [HttpGet("critical")]
        public IActionResult GetCriticalAlerts()
        {
            var alerts =
                _service.GetCriticalAlerts();

            return Ok(alerts);
        }
    }

}
