using Application.Common;

namespace Application.Privileges.UseCases.Queries
{
    public interface IUCGetPrivilegeById
    {
        Task<OperationResult<PrivilegeDTO>> ExecuteAsync(Guid id);
    }
}
