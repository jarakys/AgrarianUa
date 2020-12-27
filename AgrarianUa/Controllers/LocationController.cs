using System.Collections.Generic;
using AgrarianUa.Services;
using AgrarianUa.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AgrarianUa.Controllers
{
    [Route("api/[controller]")]
    public class LocationController : Controller
    {

        private readonly ILocationService _service;

        public LocationController(ILocationService service)
        {
            _service = service;
        }

        [HttpGet("Locations")]
        public List<LocationViewModel> Locations()
        {
            return _service.Locations();
        }

        [HttpGet("Location")]
        public LocationViewModel Location([FromForm] int id)
        {
            return _service.Location(id);
        }

        [HttpPost("Create")]
        public ActionResult Create([FromForm] string name)
        {
            _service.Add(name);
            return Ok();
        }

        [HttpPost("Update")]
        public ActionResult Update([FromForm] int id, [FromForm] string name)
        {
            _service.Update(id, name);
            return Ok();
        }

        [HttpDelete("Delete")]
        public ActionResult Delete([FromForm] int id)
        {
            if(!_service.Delete(id)) { return NotFound(); }
            return Ok();
        }
    }
}
