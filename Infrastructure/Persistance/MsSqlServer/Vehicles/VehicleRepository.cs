using Domain.Entities.Concrete.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.MsSqlServer.Vehicles
{
    public class VehicleRepository : IVehicleRepository
    {
        public Task CreateAsync(Vehicle entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vehicle>> GetAllDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Vehicle entity)
        {
            throw new NotImplementedException();
        }
    }
}
