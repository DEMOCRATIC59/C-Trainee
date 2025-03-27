using Trainee.Contracts.Requests;
using Trainee.Contracts.Responses;
using Trainee.Domain.Entities;

namespace Trainee.Application.Services
{
    public interface IVehicleService
    {
        IEnumerable<VehicleResponse> GetAll();
        VehicleResponse? GetById(int id);
        VehicleResponse Create(CreateVehicleRequest request);
        VehicleResponse? Update(UpdateVehicleRequest request);
        bool Delete(int id);
    }
}
