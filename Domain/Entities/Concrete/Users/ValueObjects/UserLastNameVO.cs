using Domain.Exceptions;
using Domain.Exceptions.Base;
using System.Text.RegularExpressions;

namespace Domain.Entities.Concrete.Users.ValueObjects
{
    public class UserLastNameVO : IValueObject
    {
        public object Value { get; private set; }

        private UserLastNameVO(string value) => Value = value;
        
        /// <summary>
        /// Factory estática para crear y validar el Value Object.
        /// </summary>
        public static UserLastNameVO Create(string lastName)
        {
            // 1. Validación de campo vacío (Fail-Fast)
            if (string.IsNullOrWhiteSpace(lastName))
                throw new DomainException("El apellido del usuario  no puede estar vacío o ser nulo.");

            var cleaned = lastName.Trim().ToUpper().ToLowerInvariant();

            // 2. Validación de Longitud (Mínimo 2, Máximo 15 caracteres)
            if (cleaned.Length < 2 || cleaned.Length > 15)
                throw new DomainException("El apellido del usuario  debe tener entre 2 y 15 caracteres.");

            // 3. Validación de Caracteres (Solo letras, acentos, ñ, espacios y guiones)
            if (!Regex.IsMatch(cleaned, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s\-]+$"))
                throw new DomainException("El apellido del usuario  contiene caracteres inválidos. Sólo se permiten letras.");

            return new UserLastNameVO(cleaned);
        }

    }
}