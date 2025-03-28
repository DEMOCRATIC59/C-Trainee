using Trainee.Application.Repositories;
using Trainee.Application.Services;
using Trainee.Contracts.Requests;
using Trainee.Contracts.Responses;
using Trainee.Domain.Entities;

namespace Trainee.Application.Services
{
    public class VehicleService
    {
        private readonly IVehicleRepository _repository;

        public VehicleService(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<VehicleResponse> GetAll()
        {
            return _repository.GetAll().Select(ToResponse);
        }

        public VehicleResponse? GetById(int id)
        {
            var vehicle = _repository.GetById(id);
            return vehicle != null ? ToResponse(vehicle) : null;
        }

        public VehicleResponse Create(CreateVehicleRequest request)
        {
            var vehicle = new Vehicle
            {
                Make = request.Make,
                Model = request.Model,
                Year = request.Year,
                Color = request.Color,
                Price = request.Price,
                Type = request.Type
            };

            var created = _repository.Add(vehicle);
            return ToResponse(created);
        }

        public VehicleResponse? Update(UpdateVehicleRequest request)
        {
            var existing = _repository.GetById(request.Id);
            if (existing == null) return null;

            existing.Make = request.Make;
            existing.Model = request.Model;
            existing.Year = request.Year;
            existing.Color = request.Color;
            existing.Price = request.Price;
            existing.Type = request.Type;

            var updated = _repository.Update(existing);
            return updated != null ? ToResponse(updated) : null;
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
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