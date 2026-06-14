using Domain.Exceptions;
using Domain.Exceptions.Base;
using System.Text.RegularExpressions;

namespace Domain.Entities.Concrete.Users.ValueObjects
{
    public sealed class UserTaxIdVO : IValueObject
    {
        public object Value { get; private set; }

        private UserTaxIdVO(string value) => Value = value;

        /// <summary>
        /// Factory estática para crear y validar el Value Object.
        /// </summary>
        public static UserTaxIdVO Create(string taxId)
        {
            if (string.IsNullOrWhiteSpace(taxId))
                throw new DomainException("La categoría fiscal no puede estar vacía o ser nula.");

            var cleaned = taxId.Trim().ToUpper().ToLower().ToLowerInvariant();

            // 2. Validación de Longitud (ej: "Exento" tiene 6, "Responsable Inscripto" tiene 21)
            if (cleaned.Length < 3 || cleaned.Length > 50)
                throw new DomainException("La categoría fiscal del usuario debe tener entre 3 y 50 caracteres.");

            // 3. Validación de Caracteres (Solo letras, espacios y tildes/eñe)
            if (!Regex.IsMatch(cleaned, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
                throw new DomainException("La categoría fiscal del usuario contiene caracteres inválidos. Sólo se permiten letras y espacios.");

            return new UserTaxIdVO(cleaned);
        }

    }
}