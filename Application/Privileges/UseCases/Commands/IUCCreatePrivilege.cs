using Application.Common;
using Application.Privileges;

namespace Application.Users.UseCases.Commands
{
    public interface IUCCreatePrivilege
    {
        Task<OperationResult> ExecuteAsync(PrivilegeDTO dto);
    }
}
