using Application.Common;

namespace Application.Users.UseCases.Queries
{
    public interface IUCGetUserById
    {
        Task<OperationResult<UserDTO>> GetByIdAsync(Guid id);
    }
}
