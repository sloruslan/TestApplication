namespace Domain.Exceptions;

public abstract class BaseException : ApplicationException
{
    public abstract int StatusCode { get; }
    public abstract string Error { get; }

    protected BaseException(string message) : base(message)
    {
        
    }

}