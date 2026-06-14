using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    public class AlreadyDeletedException : DomainException
    {
        public AlreadyDeletedException
        (  
            string message,
            string methodName,
            string className,
            ErrorCodesEnum errorCode
        
        ) : base(message, methodName, className, errorCode) { }

        public AlreadyDeletedException(string message) : base(message) { }
    }
}
