using Domain.Entities.Concrete.Privileges;
using Domain.Entities.Concrete.Users;
using Domain.Entities.Concrete.Vehicles;

namespace Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IVehicleRepository Vehicles { get; }
        IPrivilegeRepository Privileges { get; }
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);
    }
}
