using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Physicube.Application.Identity.Exceptions;

namespace Physiqube.API.Filters;

public class PhysiqubeExceptionHandler : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        switch (context.Exception)
        {
            case UserNotFoundException:
                var userNotFound = new Error
                {
                    StatusCode = 404,
                    StatusPhrase = $"{context.Exception.Message}",
                    Timestamp = DateTime.Now
                }; 
                context.Result = new JsonResult(userNotFound) { StatusCode = 404};
                break;
            case UserRegistrationFailedException:
                var loginFailed = new Error
                {
                    StatusCode = 400,
                    StatusPhrase = $"{context.Exception.Message}",
                    Timestamp = DateTime.Now
                };
                context.Result = new JsonResult(loginFailed) { StatusCode = 400};
                break;
            default:
                var error = new Error
                {
                    StatusCode = 500,
                    StatusPhrase = $"{context.Exception.Message}",
                    Timestamp = DateTime.Now
                };
                context.Result = new JsonResult(error) { StatusCode = 500};
                break;
        }
    }
}