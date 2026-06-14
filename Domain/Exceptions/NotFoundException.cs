using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    public class NotFoundException : DomainException
    {
        public NotFoundException
        (
          Guid entityId,
          string entityName,
          string message,
          string methodName,
          string className,
          ErrorCodesEnum errorCode

        ) : base(message, methodName, className, errorCode) { }
    }
}

