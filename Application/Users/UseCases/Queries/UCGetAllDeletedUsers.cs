using Application.Common;
using Domain;
using Domain.Exceptions.Base;

namespace Application.Users.UseCases.Queries
{
    public class UCGetAllDeletedUsers: IUCGetAllDeletedUsers
    {
        private readonly IUnitOfWork _uow;

        public UCGetAllDeletedUsers
        (
            IUnitOfWork uow
        )
        {
            _uow = uow ?? throw new ArgumentNullException("La Unit Of Work no puede ser nula");
        }

        public async Task<OperationResult<IEnumerable<UserDTO>>> GetAllDeletedAsync()
        {
            try
            {
                //A posteriori validar permisos en próximas iteraciones

                var users = await _uow.Users.GetAllDeletedAsync();

                return OperationResult<IEnumerable<UserDTO>>.Ok(UserMapper.ToListDTO(users));
            }
            catch (DomainException ex)
            {
                return OperationResult<IEnumerable<UserDTO>>.Fail(ex.Message);
            }
        }


        
    }
}
