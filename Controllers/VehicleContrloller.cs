using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trainee.Models;

namespace Trainee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private static List<Vehicle> _vehicles = new List<Vehicle>
        {
            new Vehicle
            {
                Id = 1,
                Make = "Toyota",
                Model = "Camry",
                Year = 2022,
                Color = "Silver",
                Price = 29999.99m,
                Type = Vehicle.VehicleType.Sedan
            },
            new Vehicle
            {
                Id = 2,
                Make = "Tesla",
                Model = "Model 3",
                Year = 2023,
                Color = "Red",
                Price = 45999.99m,
                Type = Vehicle.VehicleType.Sedan
            }
        };

        // GET: api/vehicles
        [HttpGet]
        public ActionResult<IEnumerable<Vehicle>> Get()
        {
            return _vehicles;
        }

        // GET api/vehicles/5
        [HttpGet("{id}")]
        public ActionResult<Vehicle> Get(int id)
        {
            var vehicle = _vehicles.FirstOrDefault(v => v.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return vehicle;
        }

        // POST api/vehicles
        [HttpPost]
        public ActionResult<Vehicle> Post([FromBody] Vehicle vehicle)
        {
            vehicle.Id = _vehicles.Max(v => v.Id) + 1;
            _vehicles.Add(vehicle);
            return CreatedAtAction(nameof(Get), new { id = vehicle.Id }, vehicle);
        }

        // PUT api/vehicles/5
        [HttpPut("{id}")]
        public ActionResult<Vehicle> Put(int id, [FromBody] Vehicle vehicle)
        {
            var existingVehicle = _vehicles.FirstOrDefault(v => v.Id == id);
            if (existingVehicle == null)
            {
                return NotFound();
            }

            existingVehicle.Make = vehicle.Make;
            existingVehicle.Model = vehicle.Model;
            existingVehicle.Year = vehicle.Year;
            existingVehicle.Color = vehicle.Color;
            existingVehicle.Price = vehicle.Price;
            existingVehicle.Type = vehicle.Type;

            return existingVehicle;
        }

        // DELETE api/vehicles/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var vehicle = _vehicles.FirstOrDefault(v => v.Id == id);
            if (vehicle == null)
            {
                return false;
            }
            return _vehicles.Remove(vehicle);
        }
    }
}
