using Domain.Exceptions;
using Domain.Exceptions.Base;

namespace Domain.Entities.Concrete.Vehicles.ValueObjects
{
    public class VehicleYearVO : IValueObject
    {
        public int Value { get; private set; }

        private VehicleYearVO(int value) => Value = value;

        /// <summary>
        /// Factory estática para crear y validar el Value Object.
        /// </summary>
        public static VehicleYearVO Create(int year)
        {           
            // Validaciones de negocio (Rango lógico)
            if (year < 1886 || year > DateTime.Now.Year + 1)
                throw new DomainException($"El año debe estar entre 1886 y {DateTime.Now.Year + 1}.");

            return new VehicleYearVO(year);
        }
    }
}