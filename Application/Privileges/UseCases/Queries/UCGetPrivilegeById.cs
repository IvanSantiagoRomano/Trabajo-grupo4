using Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Privileges.UseCases.Queries
{
    internal class UCGetPrivilegeById : IUCGetPrivilegeById
    {
        public Task<OperationResult<PrivilegeDTO>> ExecuteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
