using Domain.Entities.Concrete.Users;
using Domain.Exceptions;
using Domain.Exceptions.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.MsSqlServer.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Persiste un nuevo usuario en la base de datos.
        /// </summary>
        public async Task CreateAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
        }

        /// <summary>
        /// Actualiza los datos de un usuario existente.
        /// </summary>
        public Task UpdateAsync(User entity)
        {
            _context.Users.Update(entity);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Obtiene un usuario activo por su Id, incluyendo sus privilegios.
        /// </summary>
        public async Task<User> GetByIdAsync(Guid id)
        {
            var user = await _context.Users
                .Include(u => u.Privileges)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user is null)
                throw new DomainException($"No se encontró el usuario con Id '{id}'.");

            return user;
        }

        /// <summary>
        /// Obtiene todos los usuarios activos, incluyendo sus privilegios.
        /// </summary>
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await _context.Users
                .Include(u => u.Privileges)
                .ToListAsync();

            if (!users.Any())
                users = new List<User>();

            return users;
        }

        /// <summary>
        /// Elimina físicamente un usuario de la base de datos por su Id.
        /// </summary>
        public async Task DeleteAsync(Guid entityId)
        {
            var user = await _context.Users.FindAsync(entityId);
            if (user is null) return;
            _context.Users.Remove(user);
        }

        /// <summary>
        /// Pendiente de implementación. Requiere baja lógica en EntityBase (IsDeleted / DeletedAt).
        /// </summary>
        public Task<IEnumerable<User>> GetAllDeletedAsync()
        {
            throw new NotImplementedException("Requiere implementación de baja lógica en EntityBase.");
        }
    }
}
