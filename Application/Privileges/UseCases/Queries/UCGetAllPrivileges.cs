using Application.Common;
using Domain;

namespace Application.Privileges.UseCases.Queries
{
    public class UCGetAllPrivileges : IUCGetAllPrivileges
    {
        private readonly IUnitOfWork _uow;

        public UCGetAllPrivileges
        (
            IUnitOfWork uow
        )
        {
            _uow = uow ?? throw new ArgumentNullException("La Unit Of Work no puede ser nula");
        }

        public async Task<OperationResult<IEnumerable<PrivilegeDTO>>> ExecuteAsync()
        {
            throw new NotImplementedException();


            /*
              try
              {
                  return OperationResult<PrivilegeDTO>.Ok();
              }

              catch (DomainException ex)
              {
                  return OperationResult.Fail<PrivilegeDTO>(ex.Message);
              }
            */
        }
    }
}
