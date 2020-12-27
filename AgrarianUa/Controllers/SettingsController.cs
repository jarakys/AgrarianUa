using AgrarianUa.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgrarianUa.Controllers
{
    [Route("api/[controller]")]
    public class SettingsController : Controller
    {

        private readonly ISettingsService _service;

        public SettingsController(ISettingsService service)
        {
            _service = service;
        }

        [HttpPost("Update")]
        public ActionResult Update([FromForm] string deviceName, [FromForm] string deviceId /*,[FromForm] string secret */)
        {
            return Ok();
        }

        [HttpPost("Settings")]
        public ActionResult Settings([FromForm] string deviceName, [FromForm] string deviceId /*,[FromForm] string secret */)
        {
            _service.Settings(deviceName, deviceId, "");
            return Ok();
        }
    }
}
