using Application.Common;
using Domain;
using Domain.Exceptions;

namespace Application.Users.UseCases.Queries
{
    public class UCGetUserById : IUCGetUserById
    {

        private readonly IUnitOfWork _uow;

        public UCGetUserById
        (
            IUnitOfWork uow
        )
        {
            _uow = uow ?? throw new ArgumentNullException("La Unit Of Work no puede ser nula");
        }

        public async Task<OperationResult<UserDTO>> GetByIdAsync(Guid id)
        {
            try
            {
                //A posteriori validar permisos en próximas iteraciones                

                var user = await _uow.Users.GetByIdAsync(id);
                return OperationResult<UserDTO>.Ok(UserMapper.ToDTO(user));
            }
            catch (NotFoundException ex)
            {
                return OperationResult<UserDTO>.Fail(ex.Message);
            }
        }
    }
}
