using Application.Common;

namespace Application.Users.UseCases.Queries
{
    public interface IUCGetAllUsers
    {
        Task<OperationResult<IEnumerable<UserDTO>>> GetAllAsync();
    }
}
