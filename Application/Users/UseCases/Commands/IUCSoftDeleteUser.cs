using Application.Common;

namespace Application.Users.UseCases.Commands
{
    public interface IUCSoftDeleteUser
    {
        Task<OperationResult> ExecuteAsync(Guid id);
    }
}
