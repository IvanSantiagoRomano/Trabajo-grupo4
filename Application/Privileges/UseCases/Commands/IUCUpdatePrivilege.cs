using Application.Common;

namespace Application.Privileges.UseCases.Commands
{
    public interface IUCUpdatePrivilege
    {
        Task<OperationResult> ExecuteAsync(PrivilegeDTO dto);
    }
}
