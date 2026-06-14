using Domain.Exceptions;
using Domain.Exceptions.Base;

namespace Domain.Entities.Concrete.Users.ValueObjects
{
    public sealed class UserEmailVO: IValueObject
    {
        public object Value { get; }

        private UserEmailVO(string value) => Value = value;

        /// <summary>
        /// Factory estática para crear y validar el Value Object.
        /// </summary>
        public static UserEmailVO Create(string email)
        {
            // 1. Validación de campo vacío (Fail.Fast)
            if (string.IsNullOrWhiteSpace(email))
                throw new DomainException("El email del usuario no puede estar vacío");

            var cleaned = email.Trim().ToUpper().ToLowerInvariant();

            // 2. Validación de longitud
            if (cleaned.Length > 30)
                throw new DomainException("El email del usuario permite un máximo de 30 caracteres");

            // 3. Validación de arroba
            if (!cleaned.Contains("@"))
                throw new DomainException("El email del usuario debe contener @");

            // 4. Validación de punto
            if (!cleaned.Contains("."))
                throw new DomainException("El email del usuario debe contener .");


            return new UserEmailVO(cleaned);
        }
    }
}
