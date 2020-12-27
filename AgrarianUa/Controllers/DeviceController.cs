using AgrarianUa.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgrarianUa.Controllers
{
    [Route("api/[controller]")]
    public class DeviceController : Controller
    {

        private readonly IDeviceService _service;

        public DeviceController(IDeviceService service)
        {
            _service = service;
        }

        [HttpPost("Register")]
        public ActionResult Register([FromForm] string deviceName, [FromForm] string deviceId, [FromForm] int locationId)
        {
            if (!_service.Register(deviceName, deviceId, locationId)) { return BadRequest(); }

            return Ok();
        }

        [HttpPost("Device")]
        public ActionResult Device([FromForm] string deviceName, [FromForm] string deviceId, [FromForm] int locationId)
        {
            var device = _service.Device(deviceName, deviceId, locationId);
            if(device!=null) { return Ok(device); }

            return NotFound();
        }
    }
}
