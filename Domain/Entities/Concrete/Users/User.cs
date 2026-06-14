using Domain.Entities.Base;
using Domain.Entities.Concrete.Privileges;
using Domain.Entities.Concrete.Users.ValueObjects;
using Domain.Exceptions;
using Domain.Exceptions.Base;
using System.Linq;

namespace Domain.Entities.Concrete.Users
{
    public class User : EntityBase
    {
        //Parametrización no primitiva autovalidante
        public UserNicknameVO Username { get; private set; } = null!;
        public UserPasswordVO HashedPassword { get; private set; } = null!;
        public string Salt { get; private set; } = null!;
        public UserNameVO Name { get; private set; } = null!;
        public UserLastNameVO LastName { get; private set; } = null!;
        public UserTaxIdVO TaxId { get; private set; } = null!;
        public UserDocNumberVO DocNumber { get; private set; } = null!;
        public UserEmailVO Email { get; private set; } = null!;
        public UserPhoneVO PhoneNumber { get; private set; } = null!;
        public UserAddressVO Address { get; private set; } = null!;

        public List<Privilege> Privileges { get; private set; } = new List<Privilege>();


        //Constructor privado. Sí o sí se pasa por las Factories estáticas garantizando integridad de datos
        private User() { }


        // Factory para usuario NUEVO
        public static User Create
        (
            //string id => De esto se encarga EntityBase
            string username,
            string password,
            string salt,
            string name,
            string lastName,
            string taxId,
            string docNumber,
            string email,
            string phoneNumber,
            string address
        )
        {
            return new User
            {
                //Id = Guid.NewGuid() => De esto se encarga EntityBase
                Username = UserNicknameVO.Create(username),
                HashedPassword = UserPasswordVO.Create(password),
                Salt = salt,
                Name = UserNameVO.Create(name),
                LastName = UserLastNameVO.Create(lastName),
                TaxId = UserTaxIdVO.Create(taxId),
                DocNumber = UserDocNumberVO.Create(docNumber),
                Email = UserEmailVO.Create(email),
                PhoneNumber = UserPhoneVO.Create(phoneNumber),
                Address = UserAddressVO.Create(address)
            };
        }

        // Factory para usuario proveniente de Base de Datos
        public static User Reconstitute
        (
            Guid id,
            string username,
            string password,
            string salt,
            string name,
            string lastName,
            string taxId,
            string docNumber,
            string email,
            string phoneNumber,
            string address
        )
        {
            var newUser = new User()
            {
                Username = UserNicknameVO.Create(username),
                HashedPassword = UserPasswordVO.Create(password),
                Salt = salt,
                Name = UserNameVO.Create(name),
                LastName = UserLastNameVO.Create(lastName),
                TaxId = UserTaxIdVO.Create(taxId),
                DocNumber = UserDocNumberVO.Create(docNumber),
                Email = UserEmailVO.Create(email),
                PhoneNumber = UserPhoneVO.Create(phoneNumber),
                Address = UserAddressVO.Create(address)
            };
            
            newUser.UpdateId(id);
            
            return newUser;
        }

        /// <summary>
        /// API pública no estática para actualizar password.
        /// </summary>
        /// <param name="pass"></param>
        public void UpdatePassword(string pass, string salt)
        {
            HashedPassword = UserPasswordVO.Create(pass);
            Salt = salt;
        }

        /// <summary>
        /// API pública no estática para agregar permisos.
        /// </summary>
        /// <param name="pass"></param>
        public void AddPrivilege(Privilege p)
        {
            if (p == null) throw new DomainException($"El privilegio '{nameof(p)}' no puede ser nulo");

            Privileges.Add(p);
        }

        /// <summary>
        /// API pública no estática para agregar permisos.
        /// </summary>
        /// <param name="pass"></param>
        public bool HasPrivilege(Privilege p)
        {
            if (p == null) throw new DomainException("El privilegio no puede ser nulo");

            // Buscamos si existe algún elemento en la lista cuyo tipo coincida
            return Privileges.Any(x => x.GetType() == p.GetType());
        }
    }

}

