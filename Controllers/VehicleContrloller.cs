using Microsoft.AspNetCore.Mvc;
using Trainee.Models;
using System.ComponentModel.DataAnnotations;

namespace Trainee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private static List<Vehicle> _vehicles = new()
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

        /// Gets all vehicles
        [HttpGet]
        public ActionResult<IEnumerable<Vehicle>> GetAll()
        {
            return Ok(_vehicles);
        }

        /// Gets a specific vehicle by id
        [HttpGet("{id}")]
        public ActionResult<Vehicle> GetById(int id)
        {
            var vehicle = _vehicles.FirstOrDefault(v => v.Id == id);
            return vehicle == null ? NotFound() : Ok(vehicle);
        }

        /// Creates a new vehicle
        [HttpPost]
        public ActionResult<Vehicle> Create([FromBody] Vehicle vehicle)
        {
            try
            {
                vehicle.Id = _vehicles.Max(v => v.Id) + 1;
                _vehicles.Add(vehicle);
                return CreatedAtAction(nameof(GetById), new { id = vehicle.Id }, vehicle);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// Updates an existing vehicle
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Vehicle vehicle)
        {
            var existingVehicle = _vehicles.FirstOrDefault(v => v.Id == id);
            if (existingVehicle == null)
            {
                return NotFound();
            }

            try
            {
                existingVehicle.Make = vehicle.Make;
                existingVehicle.Model = vehicle.Model;
                existingVehicle.Year = vehicle.Year;
                existingVehicle.Color = vehicle.Color;
                existingVehicle.Price = vehicle.Price;
                existingVehicle.Type = vehicle.Type;

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// Deletes a specific vehicle
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var vehicle = _vehicles.FirstOrDefault(v => v.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            _vehicles.Remove(vehicle);
            return NoContent();
        }
    }
}