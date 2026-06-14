using Domain.Exceptions;
using Domain.Exceptions.Base;

namespace Domain.Entities.Concrete.Vehicles.ValueObjects
{
    public class VehicleModelVO : IValueObject
    {
        public object Value { get; private set; }
        private VehicleModelVO(string value) => Value = value;

        /// <summary>
        /// Factory estática para crear y validar el Value Object.
        /// </summary>
        public static VehicleModelVO Create(string model)
        {
            // 1. Validación de campo vacío (Fail.Fast)
            if (string.IsNullOrEmpty(model) || string.IsNullOrWhiteSpace(model))
                throw new DomainException("El modelo del vehículo es un dato obligatorio.");

            var cleaned = model.Trim().ToUpper().ToLowerInvariant();

            // 2. Validación de Longitud (Mínimo 2, Máximo 15 caracteres)
            if (cleaned.Length < 5 || cleaned.Length > 200)
                throw new DomainException("El modelo del vehículo debe tener entre 5 y 200 caracteres.");

            return new VehicleModelVO(cleaned);
        }
    }
}
