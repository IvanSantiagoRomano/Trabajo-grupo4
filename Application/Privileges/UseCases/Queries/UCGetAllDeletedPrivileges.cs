using Application.Common;
using Domain;
using Domain.Exceptions.Base;

namespace Application.Privileges.UseCases.Queries
{
    public class UCGetAllDeletedPrivileges : IUCGetAllDeletedPrivileges
    {
        private readonly IUnitOfWork _uow;

        public UCGetAllDeletedPrivileges
        (
            IUnitOfWork uow
        )
        {
            _uow = uow ?? throw new ArgumentNullException("La Unit Of Work no puede ser nula");
        }

        public async Task<OperationResult<IEnumerable<PrivilegeDTO>>> ExecuteAsync()
        {
            try
            {
                //A posteriori validar permisos en próximas iteraciones

                var privileges = await _uow.Privileges.GetAllDeletedAsync();

                return OperationResult<IEnumerable<PrivilegeDTO>>.Ok(PrivilegeMapper.ToListDTO(privileges));
            }
            catch (DomainException ex)
            {
                return OperationResult<IEnumerable<PrivilegeDTO>>.Fail(ex.Message);
            }
        }
    }
}
