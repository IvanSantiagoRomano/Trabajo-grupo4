using Application.Common;

namespace Application.Privileges.UseCases.Queries
{
    public interface IUCGetAllPrivileges
    {
        Task<OperationResult<IEnumerable<PrivilegeDTO>>> ExecuteAsync();
    }
}
