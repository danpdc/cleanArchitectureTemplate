
namespace Physicube.Application.Identity.Exceptions;

public class UserRegistrationFailedException : Exception
{
    public UserRegistrationFailedException()
    {
    }

    public UserRegistrationFailedException(string message) : base(message)
    {
    }

    public UserRegistrationFailedException(string message, Exception e) : base(message, e)
    {
        
    }
}