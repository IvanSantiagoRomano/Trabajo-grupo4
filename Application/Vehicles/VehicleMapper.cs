using Application.Privileges;
using Application.Users;
using Application.Vehicles.Enums;
using Domain.Entities.Concrete.Users;
using Domain.Entities.Concrete.Vehicles;
using Domain.Entities.Concrete.Vehicles.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Vehicles
{
    /// <summary>
    /// Clase estática que permite mappear entidades y DTOs pertenecientes a User.cs.
    /// </summary>
    public class VehicleMapper
    {
        /// <summary>
        /// Mapper estático que recibe un DTO y lo devuelve como entidad
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Vehicle ToEntity(VehicleDTO dto)
        {
            if (dto == null) throw new ArgumentNullException($"{nameof(dto)} no puede ser nulo.");

            if (dto.Id == Guid.Empty)
            {
                return Vehicle.Create
                (
                    dto.Name,
                    dto.Description,
                    dto.Model,
                    dto.Year,
                    dto.LicensePlate,
                    dto.Mileage,
                    (VehicleColorEnum)dto.Color,
                    (VehicleBrandsEnum)dto.Brand,
                    (VehicleTypesEnum)dto.Type,
                    (VehicleConditionsEnum)dto.Condition
                 );

            }

            return Vehicle.Reconstitute
            (
                dto.Id,
                dto.Name,
                dto.Description,
                dto.Model,
                dto.Year,
                dto.LicensePlate,
                dto.Mileage,
                (VehicleColorEnum)dto.Color,
                (VehicleBrandsEnum)dto.Brand,
                (VehicleTypesEnum)dto.Type,
                (VehicleConditionsEnum)dto.Condition
            );

        }


        /// <summary>
        /// Mapper estático que recibe una entidad y la devuelve como DTO
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static VehicleDTO ToDTO(Vehicle entity)
        {
            if (entity == null) throw new ArgumentNullException($"{nameof(entity)} no puede ser nulo.");

            return new VehicleDTO()
            {
                Id = entity.Id,
                Name = (string)entity.Name.Value,
                Description = (string)entity.Description.Value,
                Model = (string)entity.Model.Value,
                Year = entity.Year.Value,
                LicensePlate = (string)entity.LicensePlate.Value,
                Mileage = entity.Mileage.Value,
                Color = (VehicleColorEnumDTO)(int)entity.Color,
                Brand = (VehicleBrandsEnumDTO)(int)entity.Brand,
                Type = (VehicleTypesEnumDTO)(int)entity.Type,
                Condition = (VehicleConditionsEnumDTO)(int)entity.Condition
            };
        }

        /// <summary>
        /// Mapper que recibe un IEnumerable de DTO y devuelve una Lista de entidades
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static IEnumerable<VehicleDTO> ToListDTO(IEnumerable<Vehicle> entities) => entities?.Select(e => ToDTO(e)).ToList() ?? new List<VehicleDTO>();

        /// <summary>
        /// Mapper que recibe un IEnumerable de entidades y devuelve una Lista de DTOs
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static IEnumerable<Vehicle> ToListEntity(IEnumerable<VehicleDTO> dtos) => dtos?.Select(d => ToEntity(d)).ToList() ?? new List<Vehicle>();


    }
}
