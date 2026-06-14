using Application.Common;
using Application.Users.UseCases.Commands;
using Domain;
using Domain.Exceptions.Base;


namespace Application.Privileges.UseCases.Commands
{
    public class UCCreatePrivilege : IUCCreatePrivilege
    {
        private readonly IUnitOfWork _uow;

        public UCCreatePrivilege
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
