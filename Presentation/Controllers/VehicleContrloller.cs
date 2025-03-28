using Trainee.Application.Services;
using Trainee.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;
using Trainee.Contracts.Responses;

namespace Trainee.Presentation.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public class VehiclesController : ControllerBase
    {
        private readonly VehicleService _service;

        public VehiclesController(VehicleService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VehicleResponse>> GetAll() =>
            Ok(_service.GetAll());

        [HttpGet("{id}")]
        public ActionResult<VehicleResponse> GetById(int id) =>
            _service.GetById(id) is { } vehicle ? Ok(vehicle) : NotFound();

        [HttpPost]
        public ActionResult<VehicleResponse> Create(CreateVehicleRequest request)
        {
            var vehicle = _service.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = vehicle.Id }, vehicle);
        }

        [HttpPut("{id}")]
        public ActionResult<VehicleResponse> Update(
            [FromRoute] int id,
            [FromBody] UpdateVehicleRequest request)
        {
            request.Id = id;
            return _service.Update(request) is { } vehicle
                ? Ok(vehicle)
                : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) =>
            _service.Delete(id) ? NoContent() : NotFound();
    }
}