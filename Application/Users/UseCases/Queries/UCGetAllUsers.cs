using Application.Common;
using Domain;
using Domain.Exceptions.Base;

namespace Application.Users.UseCases.Queries
{
    public class UCGetAllUsers : IUCGetAllUsers
    {
        private readonly IUnitOfWork _uow;

        public UCGetAllUsers
        (
            IUnitOfWork uow
        )
        {
            _uow = uow ?? throw new ArgumentNullException("La Unit Of Work no puede ser nula");
        }

        public async Task<OperationResult<IEnumerable<UserDTO>>> GetAllAsync()
        {
            try
            {
                //A posteriori validar permisos en próximas iteraciones

                var users = await _uow.Users.GetAllAsync();

                return OperationResult<IEnumerable<UserDTO>>.Ok(UserMapper.ToListDTO(users));

            }

            catch (DomainException ex)
            {
                return OperationResult<IEnumerable<UserDTO>>.Fail(ex.Message);
            }
        }

    }

}

