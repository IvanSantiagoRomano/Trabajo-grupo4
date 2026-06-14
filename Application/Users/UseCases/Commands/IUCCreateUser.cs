using Application.Common;

namespace Application.Users.UseCases.Commands
{
    public interface IUCCreateUser
    {
        Task<OperationResult> ExecuteAsync(UserDTO dto);
    }
}
