using Trainee.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using Trainee.Application.Repositories;

namespace Trainee.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private static readonly List<Vehicle> _vehicles = new()
        {
            new Vehicle { Id = 1, Make = "Toyota", Model = "Camry", Year = 2022, Color = "Silver", Price = 29999.99m, Type = "Sedan" },
            new Vehicle { Id = 2, Make = "Tesla", Model = "Model 3", Year = 2023, Color = "Red", Price = 45999.99m, Type = "Sedan" }
        };

        public IEnumerable<Vehicle> GetAll() => _vehicles;

        public Vehicle? GetById(int id) => _vehicles.FirstOrDefault(v => v.Id == id);

        public Vehicle Add(Vehicle vehicle)
        {
            vehicle.Id = _vehicles.Max(v => v.Id) + 1;
            _vehicles.Add(vehicle);
            return vehicle;
        }

        public Vehicle? Update(Vehicle vehicle)
        {
            var existing = _vehicles.FirstOrDefault(v => v.Id == vehicle.Id);
            if (existing == null) return null;

            existing.Make = vehicle.Make;
            existing.Model = vehicle.Model;
            existing.Year = vehicle.Year;
            existing.Color = vehicle.Color;
            existing.Price = vehicle.Price;
            existing.Type = vehicle.Type;

            return existing;
        }

        public bool Delete(int id)
        {
            var vehicle = _vehicles.FirstOrDefault(v => v.Id == id);
            return vehicle != null && _vehicles.Remove(vehicle);
        }
    }
}