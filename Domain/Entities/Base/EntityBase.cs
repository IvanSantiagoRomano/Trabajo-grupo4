using Domain.Exceptions;

namespace Domain.Entities.Base
{
    public partial class EntityBase
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public bool IsDeleted { get; private set; } = false;


        public void MarkAsDeleted()
        {
            if (IsDeleted == true) throw new AlreadyDeletedException("No se puede borrar una entidad borrada");
            IsDeleted = true;
        }

        public void UpdateId(Guid id) => Id = id;
    }
}
