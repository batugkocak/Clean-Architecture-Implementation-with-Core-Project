namespace Core.CrossCuttingConcerns.Exceptions.Types;

public class BusinessException : Exception
{
    public BusinessException() { }
    public BusinessException(string? message) : base(message) { }
    // Inner expception is not used generally, but it is here for good practices.
    public BusinessException(string? message, Exception? innerException) : base(message, innerException) { }
}