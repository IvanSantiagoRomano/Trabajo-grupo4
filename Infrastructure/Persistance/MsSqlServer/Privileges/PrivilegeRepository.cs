using Domain.Entities.Concrete.Privileges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.MsSqlServer.Privileges
{
    public class PrivilegeRepository : IPrivilegeRepository
    {
        public Task CreateAsync(Privilege entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Privilege>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Privilege>> GetAllDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Privilege> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Privilege entity)
        {
            throw new NotImplementedException();
        }
    }
}
