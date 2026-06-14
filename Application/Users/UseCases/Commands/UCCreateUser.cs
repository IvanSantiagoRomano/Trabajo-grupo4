using Application.Common;
using Domain;
using Domain.Exceptions;

namespace Application.Users.UseCases.Commands
{
    public class UCCreateUser : IUCCreateUser
    {
        private readonly IUnitOfWork _uow;

        public UCCreateUser
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
                //A posteriori validar permisos en próximas iteraciones                


                //1. Se comienza transacción
                await _uow.BeginTransactionAsync();
                

                //2. Se intenta crear la entidad basada en el DTO
                await _uow.Users.CreateAsync(UserMapper.ToEntity(dto));
                await _uow.CommitAsync();


                //3. Se retorna OperationResult sólo con Success = true. No hay Data de vuelta.
                return OperationResult.Ok();
            }
            catch (NotFoundException ex)
            {
                await _uow.RollbackAsync();

                return OperationResult.Fail(ex.Message);
            }
            

        }
    }
}
