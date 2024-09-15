namespace Physicube.Application.Identity.Exceptions;

public class LoginFailedException : Exception
{
    public LoginFailedException()
    {
    }
    
    public LoginFailedException(string message) : base(message)
    {
        
    }
    
    public LoginFailedException(string message, Exception innerException) : base(message, innerException)
    {
        
    }
}