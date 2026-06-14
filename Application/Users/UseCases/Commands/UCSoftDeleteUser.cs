using Application.Common;
using Domain;
using Domain.Exceptions;

namespace Application.Users.UseCases.Commands
{
    public class UCSoftDeleteUser: IUCSoftDeleteUser
    {
        private readonly IUnitOfWork _uow;

        public UCSoftDeleteUser
        (
            IUnitOfWork uow
        )
        {
            _uow = uow ?? throw new ArgumentNullException("La Unit Of Work no puede ser nula");
        }

        public async Task<OperationResult> ExecuteAsync(Guid id)
        {
            try
            {
                //A posteriori validar permisos en próximas iteraciones                


                //1. Se comienza transacción
                await _uow.BeginTransactionAsync();

                //2. Se busca entidad y borra lógicamente
                var entity = await _uow.Users.GetByIdAsync(id);
                entity.MarkAsDeleted();

                //3. Se actualiza con el nuevo estado
                await _uow.Users.UpdateAsync(entity);
                await _uow.CommitAsync();

                //4. Se retorna OperationResult sólo con Success = true. No hay Data de vuelta.
                return OperationResult.Ok();
            }
            catch (AlreadyDeletedException ex)
            {
                await _uow.RollbackAsync();
                return OperationResult.Fail(ex.Message);
            }
        }
    }
}
