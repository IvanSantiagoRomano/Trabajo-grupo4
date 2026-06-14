using Domain.Exceptions;
using Domain.Exceptions.Base;
using System.Text.RegularExpressions;

namespace Domain.Entities.Concrete.Users.ValueObjects
{
    public sealed class UserDocNumberVO : IValueObject
    {
        public object Value { get; private set; }

        private UserDocNumberVO(string value) => Value = value;

        /// <summary>
        /// Factory estática para crear y validar el Value Object.
        /// </summary>
        public static UserDocNumberVO Create(string docNumber)
        {
            // 1. Validación de campo vacío (Fail.Fast)
            if (string.IsNullOrWhiteSpace(docNumber))
                throw new DomainException("El número de documento del usuario no puede estar vacío o ser nulo.");

            var cleaned = docNumber.Trim().ToUpper().ToLowerInvariant();
                
            // 2. Sanitización: Quitamos puntos y guiones que suelen venir en DNIs o CUITs/CUILs
            cleaned = cleaned.Replace(".", "").Replace("-", "");

            // 3. Validación de Longitud (DNI: 7-8 dígitos, CUIT/CUIL: 11 dígitos)
            if (cleaned.Length < 7 || cleaned.Length > 11)
                throw new DomainException("El número de documento del usuario debe tener entre 7 y 11 dígitos válidos.");

            // 4. Validación de Caracteres (Solo números)
            if (!Regex.IsMatch(cleaned, @"^[0-9]+$"))
                throw new DomainException("El número de documento del usuario contiene caracteres inválidos. Solo se permiten números.");

            return new UserDocNumberVO(cleaned);
        }

    }
}