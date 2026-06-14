using Domain.Exceptions;
using Domain.Exceptions.Base;

namespace Domain.Entities.Concrete.Users.ValueObjects
{
    public sealed class UserPhoneVO : IValueObject
    {
        public object Value { get; }

        private UserPhoneVO(string value) => Value = value;

        /// <summary>
        /// Factory estática para crear y validar el Value Object.
        /// </summary>
        public static UserPhoneVO Create(string phone)
        {
            // 1. Validación de campo vacío (Fail-Fast)
            if (string.IsNullOrWhiteSpace(phone))
                throw new DomainException("El número de teléfono del usuario no puede estar vacío");

            var cleaned = phone.Trim();

            // Sanitización: conservamos sólo dígitos y el + inicial
            bool hasPlus = cleaned.StartsWith("+");
            var sanitized = (hasPlus ? "+" : "") + new string(cleaned.Where(char.IsDigit).ToArray());

            // 2. Longitud de 8 a 15 caracteres
            if (sanitized.Length < 8 || sanitized.Length > 15)
                throw new DomainException("El número de teléfono del usuario debe tener entre 8 y 15 caracteres");

            // 3. NO permite letras (validación explícita que pediste)
            if (cleaned.Any(char.IsLetter))
                throw new DomainException("El número de teléfono del usuario no puede contener letras");

            // 4. Solo caracteres permitidos en el input original
            if (!cleaned.All(c => char.IsDigit(c) || c == '+' || c == ' ' || c == '-' || c == '(' || c == ')'))
                throw new DomainException("El número de teléfono del usuario sólo puede contener dígitos, +, -, espacios o paréntesis");

            // 5. Debe tener al menos 7 dígitos reales
            if (sanitized.Count(char.IsDigit) < 7)
                throw new DomainException("El número de teléfono debe contener al menos 7 dígitos");

            return new UserPhoneVO(sanitized);
        }
    }
}
