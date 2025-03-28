using Trainee.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Trainee.Application.Repositories
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> GetAll();
        Vehicle? GetById(int id);
        Vehicle Add(Vehicle vehicle);
        Vehicle? Update(Vehicle vehicle);
        bool Delete(int id);
    }
}