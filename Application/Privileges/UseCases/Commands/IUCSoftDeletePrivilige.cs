using Application.Common;

namespace Application.Privileges.UseCases.Commands
{
    public interface IUCSoftDeletePrivilige
    {
        Task<OperationResult> ExecuteAsync(PrivilegeDTO dto);
    }
}
