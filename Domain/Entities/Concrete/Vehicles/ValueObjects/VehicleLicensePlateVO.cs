using Domain.Exceptions;
using Domain.Exceptions.Base;
using System.Text.RegularExpressions;

namespace Domain.Entities.Concrete.Vehicles.ValueObjects
{
    public class VehicleLicensePlateVO : IValueObject
    {
        public object Value { get; private set; }
        private VehicleLicensePlateVO(string value) => Value = value;

        /// <summary>
        /// Factory estática para crear y validar el Value Object.
        /// </summary>
        public static VehicleLicensePlateVO Create(string licensePlate)
        {
            if (string.IsNullOrWhiteSpace(licensePlate))
                throw new DomainException("La patente del vehículo es un dato obligatorio.");

            // 1. Sanitización: Eliminar guiones, puntos, comas y espacios. 
            string cleaned = Regex.Replace(licensePlate, @"[^a-zA-Z0-9]", "");

            // 2. Validación de Longitud
            if (cleaned.Length < 6 || cleaned.Length > 15)
                throw new DomainException("La patente debe contener entre 6 y 15 caracteres alfanuméricos válidos.");

            // 3. Normalización a mayúsculas para consistencia en BBDD
            return new VehicleLicensePlateVO(cleaned.ToUpper());
        }
    }
}
