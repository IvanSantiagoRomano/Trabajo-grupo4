using Domain.Entities.Base;
using Domain.Entities.Concrete.Privileges.ValueObjects;

namespace Domain.Entities.Concrete.Privileges
{
    public class Privilege : EntityBase
    {
        public PrivilegeDescriptionVO Description { get; private set; } = null!;

        private Privilege() { }

        // Factory para prvilegio NUEVO
        public static Privilege Create
        (            
            string description
        )
        {
            //Un privilegio en creación no puede tener un Id. Se crea en tiempo de ejecución desde EntityBase.
            return new Privilege
            {
                Description = PrivilegeDescriptionVO.Create(description),
            };
        }

        // Factory para usuario proveniente de Base de Datos
        public static Privilege Reconstitute
        (
            Guid id,
            string description,
            bool isDeleted
        )
        {
            var newPrivilege = new Privilege
            {
                Description = PrivilegeDescriptionVO.Create(description)
            };

            newPrivilege.UpdateId(id);
            newPrivilege.MarkAsDeleted();

            return newPrivilege;
        }



    }
}
