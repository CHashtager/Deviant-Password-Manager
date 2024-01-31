namespace DeviantPasswordManager.Core.Exceptions;

public class InvalidTokenException : Exception
{
    public InvalidTokenException() : base("Invalid Token")
    {
    }
}
