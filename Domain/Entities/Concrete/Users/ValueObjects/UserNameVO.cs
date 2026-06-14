using Domain.Exceptions;
using Domain.Exceptions.Base;
using System;
using System.Text.RegularExpressions;

namespace Domain.Entities.Concrete.Users.ValueObjects
{
    public sealed class UserNameVO : IValueObject
    {
        public object Value { get; private set; }
        private UserNameVO(string value) => Value = value;

        /// <summary>
        /// Factory estática para crear y validar el Value Object.
        /// </summary>
        public static UserNameVO Create(string name)
        {
            // 1. Validación de campo vacío (Fail.Fast)
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                throw new DomainException("El nombre del usuario es un dato obligatorio.");

            var cleaned = name.Trim().ToUpper().ToLowerInvariant();

            // 2. Validación de Longitud (Mínimo 2, Máximo 15 caracteres)
            if (cleaned.Length < 5 || cleaned.Length > 15)
                throw new DomainException("El nombre del usuario debe tener entre 5 y 15 caracteres.");

            // 3. Validación de Caracteres (Solo letras, acentos, ñ, espacios y guiones) > (Evita números y símbolos raros como @, !, $, etc.)
            if (!Regex.IsMatch(cleaned, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s\-]+$"))
                throw new DomainException("El nombre del usuario contiene caracteres inválidos. Sólo se permiten letras.");

            return new UserNameVO(cleaned);
        } 
    }
}