using Domain;
using Domain.Entities.Concrete.Privileges;
using Domain.Entities.Concrete.Users;
using Domain.Entities.Concrete.Vehicles;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Persistance
{
    /// <summary>
    /// Implementación del patrón Unit of Work para gestionar transacciones y repositorios.
    /// Coordina el trabajo de múltiples repositorios y asegura la integridad de los datos mediante transacciones.
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
        private IDbContextTransaction? _transaction;

        public IUserRepository Users { get; }
        public IVehicleRepository Vehicles { get; }
        public IPrivilegeRepository Privileges { get; }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="UnitOfWork"/>. Todos los parámetros son obligatorios.
        /// </summary>
        public UnitOfWork
        (
            AppDbContext context,
            IUserRepository users,
            IVehicleRepository vehicles,
            IPrivilegeRepository privileges
        )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "El contexto de base de datos no puede ser nulo.");
            Users = users ?? throw new ArgumentNullException(nameof(users), "El repositorio de usuarios no puede ser nulo.");
            Vehicles = vehicles ?? throw new ArgumentNullException(nameof(vehicles), "El repositorio de vehículos no puede ser nulo.");
            Privileges = privileges ?? throw new ArgumentNullException(nameof(privileges), "El repositorio de privilegios no puede ser nulo.");
        }

        /// <summary>
        /// Inicia una nueva transacción en el contexto de base de datos actual.
        /// </summary>
        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
            => _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        /// <summary>
        /// Guarda los cambios pendientes y confirma la transacción actual.
        /// </summary>
        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);

            if (_transaction != null)
            {
                await _transaction.CommitAsync(cancellationToken);
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        /// <summary>
        /// Revierte los cambios realizados durante la transacción actual.
        /// </summary>
        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync(cancellationToken);
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        /// <summary>
        /// Libera los recursos utilizados por el contexto de base de datos.
        /// </summary>
        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}