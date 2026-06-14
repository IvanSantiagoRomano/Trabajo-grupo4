using Domain.Entities.Concrete.Privileges;

namespace Application.Privileges
{
    /// <summary>
    /// Clase estática que permite mappear entidades y DTOs pertenecientes a Privilege.cs.
    /// </summary>
    public static class PrivilegeMapper
    {
        /// <summary>
        /// Mapper estático que recibe un DTO y lo devuelve como entidad
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Privilege ToEntity(PrivilegeDTO dto)
        {
            if (dto == null) throw new ArgumentNullException($"{nameof(dto)} no puede ser nulo.");

            if (dto.Id == Guid.Empty)
            {
                return Privilege.Create
                (
                    dto.Description
                );
            }

            return Privilege.Reconstitute
            (
                dto.Id,
                dto.Description,
                dto.IsDeleted
            );
        }

        /// <summary>
        /// Mapper estático que recibe una entidad y la devuelve como DTO
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static PrivilegeDTO ToDTO(Privilege entity)
        {
            if (entity == null) throw new ArgumentNullException($"{nameof(entity)} no puede ser nulo.");

            return new PrivilegeDTO()
            {
                Id = entity.Id,
                IsDeleted = entity.IsDeleted,
                Description = entity.Description.Value                
            };
        }

        /// <summary>
        /// Mapper que recibe un IEnumerable de DTO y devuelve una Lista de entidades
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static IEnumerable<PrivilegeDTO> ToListDTO(IEnumerable<Privilege> entities) => entities?.Select(e => ToDTO(e)).ToList() ?? new List<PrivilegeDTO>();

        /// <summary>
        /// Mapper que recibe un IEnumerable de entidades y devuelve una Lista de DTOs
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static IEnumerable<Privilege> ToListEntity(IEnumerable<PrivilegeDTO> dtos) => dtos?.Select(d => ToEntity(d)).ToList() ?? new List<Privilege>();



    }
}
