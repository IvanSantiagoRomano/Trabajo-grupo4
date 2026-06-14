using Domain.Exceptions;
using Domain.Exceptions.Base;

namespace Domain.Entities.Concrete.Vehicles.ValueObjects
{
    public sealed class VehicleDescriptionVO : IValueObject
    {
        public object Value { get; private set; }
        private VehicleDescriptionVO(string value) => Value = value;

        /// <summary>
        /// Factory estática para crear y validar el Value Object.
        /// </summary>
        public static VehicleDescriptionVO Create(string description)
        {
            // 1. Validación de campo vacío (Fail.Fast)
            if (string.IsNullOrEmpty(description) || string.IsNullOrWhiteSpace(description))
                throw new DomainException("La descripción del vehículo es un dato obligatorio.");

            var cleaned = description.Trim().ToUpper().ToLowerInvariant();

            // 2. Validación de Longitud (Mínimo 2, Máximo 15 caracteres)
            if (cleaned.Length < 5 || cleaned.Length > 200)
                throw new DomainException("La descripción del vehículo debe tener entre 5 y 200 caracteres.");

            return new VehicleDescriptionVO(cleaned);
        }
    }
}
