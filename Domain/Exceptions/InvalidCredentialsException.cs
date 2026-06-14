using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    public class InvalidCredentialsException : DomainException
    {

        public InvalidCredentialsException
        (
            string message,
            string methodName,
            string className,
            ErrorCodesEnum errorCode

        ) : base(message, methodName, className, errorCode) { }

        public InvalidCredentialsException(string message) : base(message) { }
    }
}
