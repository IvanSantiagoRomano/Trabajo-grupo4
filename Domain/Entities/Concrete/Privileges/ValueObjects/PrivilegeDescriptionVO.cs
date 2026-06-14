using Domain.Entities.Concrete.Vehicles.ValueObjects;
using Domain.Exceptions;
using Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Domain.Entities.Concrete.Privileges.ValueObjects
{
    public class PrivilegeDescriptionVO: IValueObject
    {
        public string Value { get; private set; }

        private PrivilegeDescriptionVO(string value) => Value = value;

        /// <summary>
        /// Factory estática para crear y validar el Value Object.
        /// </summary>
        public static PrivilegeDescriptionVO Create(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new DomainException("La descripción del privilegio es un dato obligatorio.");

            // Sanitización: quitar espacios
            string cleaned = description.Trim();

            if (cleaned.Length < 10 || cleaned.Length > 100)
                throw new DomainException("La descripción del privilegio debe contener entre 10 y 100 caracteres.");

            return new PrivilegeDescriptionVO(description);
        }
    }
}
