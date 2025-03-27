using Trainee.Application.Services;
using Trainee.Contracts.Requests;
using Trainee.Contracts.Responses;
using Trainee.Domain.Entities;
using Trainee.Domain.Enums;

namespace Trainee.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private static readonly List<Vehicle> _vehicles = new()
            {
                new Vehicle { Id = 1, Make = "Toyota", Model = "Camry", Year = 2022, Color = "Silver", Price = 29999.99m, Type = "Sedan" },
                new Vehicle { Id = 2, Make = "Tesla", Model = "Model 3", Year = 2023, Color = "Red", Price = 45999.99m, Type = "Sedan" }
            };

        public IEnumerable<VehicleResponse> GetAll()
        {
            return _vehicles.Select(v => new VehicleResponse
            {
                Id = v.Id,
                Make = v.Make,
                Model = v.Model,
                Year = v.Year,
                Color = v.Color,
                Price = v.Price,
                Type = v.Type
            });
        }

        public VehicleResponse? GetById(int id)
        {
            var vehicle = _vehicles.FirstOrDefault(v => v.Id == id);
            return vehicle == null ? null : new VehicleResponse
            {
                Id = vehicle.Id,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Year = vehicle.Year,
                Color = vehicle.Color,
                Price = vehicle.Price,
                Type = vehicle.Type
            };
        }

        public VehicleResponse Create(CreateVehicleRequest request)
        {
            var vehicle = new Vehicle
            {
                Id = _vehicles.Max(v => v.Id) + 1,
                Make = request.Make,
                Model = request.Model,
                Year = request.Year,
                Color = request.Color,
                Price = request.Price,
                Type = request.Type
            };
            _vehicles.Add(vehicle);
            return ToResponse(vehicle);
        }

        public VehicleResponse? Update(UpdateVehicleRequest request)
        {
            var vehicle = _vehicles.FirstOrDefault(v => v.Id == request.Id);
            if (vehicle == null) return null;

            vehicle.Make = request.Make;
            vehicle.Model = request.Model;
            vehicle.Year = request.Year;
            vehicle.Color = request.Color;
            vehicle.Price = request.Price;
            vehicle.Type = request.Type;

            return ToResponse(vehicle);
        }

        public bool Delete(int id)
        {
            var vehicle = _vehicles.FirstOrDefault(v => v.Id == id);
            return vehicle != null && _vehicles.Remove(vehicle);
        }

        private static VehicleResponse ToResponse(Vehicle vehicle)
        {
            return new VehicleResponse
            {
                Id = vehicle.Id,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Year = vehicle.Year,
                Color = vehicle.Color,
                Price = vehicle.Price,
                Type = vehicle.Type
            };
        }
    }
}