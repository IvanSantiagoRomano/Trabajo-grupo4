namespace Application.Common
{
    public class OperationResult<T>
    {
        public bool Success { get; private set; }
        public T? Data { get; private set; }
        public string? ErrorMessage { get; private set; } 

        public static OperationResult<T> Ok(T data) => new() { Success = true, Data = data };
        public static OperationResult<T> Fail(string error) => new() { Success = false, ErrorMessage = error };
    }

    public class OperationResult
    {
        public bool Success { get; private set; }       
        public string? ErrorMessage { get; private set; }
        
        public static OperationResult Ok() => new() { Success = true };
        public static OperationResult Fail(string error) => new() { Success = false, ErrorMessage = error };
    }
}
