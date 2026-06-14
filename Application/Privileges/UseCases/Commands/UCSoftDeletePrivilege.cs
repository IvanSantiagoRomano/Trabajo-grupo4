using Application.Common;
using Domain;
using Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Privileges.UseCases.Commands
{
    public class UCSoftDeletePrivilege: IUCSoftDeletePrivilige
    {
        private readonly IUnitOfWork _uow;

        public UCSoftDeletePrivilege
        (
            IUnitOfWork uow
        )
        {
            _uow = uow ?? throw new ArgumentNullException("La Unit Of Work no puede ser nula");
        }

        public async Task<OperationResult> ExecuteAsync(PrivilegeDTO dto)
        {
            throw new NotImplementedException();


            try
            {
                return OperationResult.Ok();
            }

            catch (DomainException ex)
            {
                return OperationResult.Fail(ex.Message);
            }

        }
    }
}
