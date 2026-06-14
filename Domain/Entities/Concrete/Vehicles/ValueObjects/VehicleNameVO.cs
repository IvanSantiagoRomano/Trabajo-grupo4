using Domain.Exceptions;
using Domain.Exceptions.Base;

namespace Domain.Entities.Concrete.Vehicles.ValueObjects
{
    public sealed class VehicleNameVO : IValueObject
    {
        public object Value { get; private set; }
        private VehicleNameVO(string value) => Value = value;

        /// <summary>
        /// Factory estática para crear y validar el Value Object.
        /// </summary>
        public static VehicleNameVO Create(string name)
        {
            // 1. Validación de campo vacío (Fail.Fast)
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                throw new DomainException("El nombre del vehículo es un dato obligatorio.");

            var cleaned = name.Trim().ToUpper().ToLowerInvariant();

            // 2. Validación de Longitud (Mínimo 2, Máximo 15 caracteres)
            if (cleaned.Length < 5 || cleaned.Length > 15)
                throw new DomainException("El nombre del vehículo debe tener entre 5 y 15 caracteres.");

            return new VehicleNameVO(cleaned);
        }
    }
}
