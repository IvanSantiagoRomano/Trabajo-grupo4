using Domain.Exceptions;
using Domain.Exceptions.Base;

namespace Domain.Entities.Concrete.Vehicles.ValueObjects
{
    public class VehicleMileageVO : IValueObject
    {
        public int Value { get; private set; }

        private VehicleMileageVO(int value) => Value = value;

        /// <summary>
        /// Factory estática para crear y validar el kilometraje del vehículo.
        /// </summary>
        public static VehicleMileageVO Create(int mileage)
        {
            // No puede ser negativo
            if (mileage < 0)
                throw new DomainException("El kilometraje no puede ser un valor negativo.");

            // Un techo lógico razonable
            if (mileage > 1000000)
                throw new DomainException("El kilometraje ingresado supera el límite permitido para este sistema.");

            return new VehicleMileageVO(mileage);
        }
    }
}