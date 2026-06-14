using Application.Privileges;
using Domain.Entities.Concrete.Users;

namespace Application.Users
{
    /// <summary>
    /// Clase estática que permite mappear entidades y DTOs pertenecientes a User.cs.
    /// </summary>
    public static class UserMapper
    {
        /// <summary>
        /// Mapper estático que recibe un DTO y lo devuelve como entidad
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static User ToEntity(UserDTO dto)
        {
            if (dto == null) throw new ArgumentNullException($"{nameof(dto)} no puede ser nulo.");

            if (dto.Id == Guid.Empty)
            {
                var newUser = User.Create
                (
                    dto.Username,
                    dto.Password,
                    dto.Salt,
                    dto.Name,
                    dto.LastName,
                    dto.TaxId,
                    dto.DocNumber,
                    dto.Email,
                    dto.PhoneNumber,
                    dto.Address
                );

                foreach (PrivilegeDTO pDto in dto.Privileges)
                {
                    newUser.AddPrivilege(PrivilegeMapper.ToEntity(pDto));
                }

                return newUser;
            }

            var newExistantUser = User.Reconstitute
            (
                dto.Id,
                dto.Username,
                dto.Password,
                dto.Salt,
                dto.Name,
                dto.LastName,
                dto.TaxId,
                dto.DocNumber,
                dto.Email,
                dto.PhoneNumber,
                dto.Address
            );
        
            foreach (PrivilegeDTO pDto in dto.Privileges)
            {
                newExistantUser.AddPrivilege(PrivilegeMapper.ToEntity(pDto));
            }

            return newExistantUser;
        }

        /// <summary>
        /// Mapper estático que recibe una entidad y la devuelve como DTO
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static UserDTO ToDTO(User entity)
        {
            if (entity == null) throw new ArgumentNullException($"{nameof(entity)} no puede ser nulo.");

            return new UserDTO()
            {
                Id = entity.Id,
                Username = (string)entity.Username.Value,
                Password = (string)entity.HashedPassword.Value,
                Name = (string)entity.Name.Value,
                LastName = (string)entity.LastName.Value,
                TaxId = (string)entity.TaxId.Value,
                DocNumber = (string)entity.DocNumber.Value,
                Email = (string)entity.Email.Value,
                PhoneNumber = (string)entity.PhoneNumber.Value,
                Address = (string)entity.Address.Value,

                Privileges = PrivilegeMapper.ToListDTO(entity.Privileges).ToList()
            };
        }

        /// <summary>
        /// Mapper que recibe un IEnumerable de DTO y devuelve una Lista de entidades
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static IEnumerable<UserDTO> ToListDTO(IEnumerable<User> entities) => entities?.Select(e => ToDTO(e)).ToList() ?? new List<UserDTO>();

        /// <summary>
        /// Mapper que recibe un IEnumerable de entidades y devuelve una Lista de DTOs
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static IEnumerable<User> ToListEntity(IEnumerable<UserDTO> dtos) => dtos?.Select(d => ToEntity(d)).ToList() ?? new List<User>();



    }
}
