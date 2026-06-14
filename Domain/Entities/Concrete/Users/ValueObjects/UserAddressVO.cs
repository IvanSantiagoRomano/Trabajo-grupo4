using Domain.Exceptions;
using Domain.Exceptions.Base;
using System.Text.RegularExpressions;

namespace Domain.Entities.Concrete.Users.ValueObjects
{
    public sealed class UserAddressVO : IValueObject
    {
        public object Value { get; private set; }

        private UserAddressVO(string value) => Value = value;

        /// <summary>
        /// Factory estática para crear y validar el Value Object.
        /// </summary>
        public static UserAddressVO Create(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new DomainException("La dirección de envío del usuario no puede estar vacía o ser nula.");

            if (string.IsNullOrEmpty(address))
                throw new DomainException("La dirección de envío del usuario no puede estar vacía o ser nula.");

            var cleaned = address.Trim().ToUpper().ToLowerInvariant();

            // 2. Validación de Longitud (Mínimo 2, Máximo 150 caracteres)
            if (cleaned.Length < 2 || cleaned.Length > 150)
                throw new DomainException("La dirección de envío del usuario debe tener entre 2 y 150 caracteres.");

            // 3. Validación de Caracteres (Letras, números, acentos, ñ, espacios, comas, puntos, guiones y símbolos de número/piso)
            if (!Regex.IsMatch(cleaned, @"^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ\s\-\.,#ºª]+$"))
                throw new DomainException("La dirección de envío del usuario contiene caracteres inválidos.");

            return new UserAddressVO(cleaned);
        }

    }
}