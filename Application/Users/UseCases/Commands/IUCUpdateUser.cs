using Application.Common;

namespace Application.Users.UseCases.Commands
{
    public interface IUCUpdateUser
    {
        Task<OperationResult> ExecuteAsync(UserDTO dto);
    }
}
