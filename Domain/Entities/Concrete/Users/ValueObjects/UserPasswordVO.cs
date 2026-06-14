using Domain.Exceptions;
using Domain.Exceptions.Base;

namespace Domain.Entities.Concrete.Users.ValueObjects
{
    public class UserPasswordVO : IValueObject
    {
        public string Value { get; private set; }
        private UserPasswordVO(string value) => Value = value;

        /// <summary>
        /// Factory estática para crear y validar el Value Object.
        /// </summary>
        public static UserPasswordVO Create(string password)
        {

            return new UserPasswordVO(password);

            if (string.IsNullOrWhiteSpace(password))
                throw new DomainException("La contraseña del usuario es un dato obligatorio.");

            var cleaned = password.Trim();

            if (cleaned.Length < 5 || cleaned.Length > 15)
                throw new DomainException("La contraseña del usuario debe tener entre 5 y 15 caracteres.");

            if (!cleaned.Any(char.IsLetter))
                throw new DomainException("La contraseña debe contener al menos una letra.");

            if (!cleaned.Any(char.IsDigit))
                throw new DomainException("La contraseña debe contener al menos un número.");

            return new UserPasswordVO(cleaned);
        }
    }
}
