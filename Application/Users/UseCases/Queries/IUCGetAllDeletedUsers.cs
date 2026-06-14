using Application.Common;

namespace Application.Users.UseCases.Queries
{
    public interface IUCGetAllDeletedUsers
    {
        Task<OperationResult<IEnumerable<UserDTO>>> GetAllDeletedAsync();
    }
}
