using Domain.Entities.Concrete.Privileges.RefreshTokens;

namespace Application.RefreshTokens
{
    public class RefreshTokenMapper
    {
        /// <summary>
        /// Mapper estático que recibe un DTO y lo devuelve como entidad
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static RefreshToken ToEntity(RefreshTokenDTO dto)
        {
            if (dto == null) throw new ArgumentNullException($"{nameof(dto)} no puede ser nulo.");

            return RefreshToken.Create
            (
                dto.UserId,
                dto.Token,
                dto.Expires
            );
        }


        /// <summary>
        /// Mapper estático que recibe una entidad y la devuelve como DTO
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static RefreshTokenDTO ToDTO(RefreshToken entity)
        {
            if (entity == null) throw new ArgumentNullException($"{nameof(entity)} no puede ser nulo.");

            return new RefreshTokenDTO()
            {
                Id = entity.Id,
                UserId = entity.UserId,
                Token = entity.Token,
                Expires = entity.Expires
            };
        }
    }
}
