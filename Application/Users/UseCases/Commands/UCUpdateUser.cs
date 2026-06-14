using Application.Common;
using Domain;
using Domain.Exceptions.Base;

namespace Application.Users.UseCases.Commands
{
    public class UCUpdateUser : IUCUpdateUser
    {

        private readonly IUnitOfWork _uow;

        public UCUpdateUser
        (
            IUnitOfWork uow
        )
        {
            _uow = uow ?? throw new ArgumentNullException("La Unit Of Work no puede ser nula");
        }


        public async Task<OperationResult> ExecuteAsync(UserDTO dto)
        {
            try
            {
                await _uow.BeginTransactionAsync();

                var entity = UserMapper.ToEntity(dto);

                await _uow.Users.UpdateAsync(entity);
                await _uow.CommitAsync();




                return OperationResult.Ok();
            }

            catch (DomainException ex)
            {
                await _uow.RollbackAsync();

                return OperationResult.Fail(ex.Message);
            }

        }
    }
}
