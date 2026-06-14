using Application.Common;

namespace Application.Privileges.UseCases.Queries
{
    public interface IUCGetAllDeletedPrivileges
    {
        Task<OperationResult<IEnumerable<PrivilegeDTO>>> ExecuteAsync();
    }
}
