namespace Domain.Exceptions.Base
{
    public class DomainException : Exception
    {
        /// <summary>
        /// Excepción custom para filtrar por errores de integridad, no negocio.
        /// </summary>
        /// <param name="message"></param>
        public DomainException
        (
            string message,
            string methodName,
            string className,
            ErrorCodesEnum errorCode

        ) : base(message) { }
        public DomainException(string message):base(message) { }
        public string MethodName { get; private set; } = null!;
        public string ClassName { get; private set; } = null!;
        public DateTime TimeStamp { get; private set; } = DateTime.UtcNow;
        public ErrorCodesEnum errorCode { get; private set; }


    }
}
