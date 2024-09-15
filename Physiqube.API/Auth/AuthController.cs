using MediatR;
using Microsoft.AspNetCore.Mvc;
using Physicube.Application.Identity;

namespace Physiqube.API.Auth;

[ApiController]
[Route("/api/auth")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(Register request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
    
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(Login request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}