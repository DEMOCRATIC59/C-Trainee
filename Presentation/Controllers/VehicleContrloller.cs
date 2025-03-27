using Trainee.Application.Services;
using Trainee.Contracts.Requests;
using Trainee.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Trainee.Contracts.Responses;

namespace Trainee.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VehicleResponse>> GetAll()
        {
            return Ok(_vehicleService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<VehicleResponse> GetById(int id)
        {
            var vehicle = _vehicleService.GetById(id);
            return vehicle == null ? NotFound() : Ok(vehicle);
        }

        [HttpPost]
        public ActionResult<VehicleResponse> Create([FromBody] CreateVehicleRequest request)
        {
            var vehicle = _vehicleService.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = vehicle.Id }, vehicle);
        }

        [HttpPut("{id}")]
        public ActionResult<VehicleResponse> Update(
            [FromRoute] int id,
            [FromBody] UpdateVehicleRequest request)
        {
            request.Id = id;
            var vehicle = _vehicleService.Update(request);
            return vehicle == null ? NotFound() : Ok(vehicle);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _vehicleService.Delete(id) ? NoContent() : NotFound();
        }
    }
}