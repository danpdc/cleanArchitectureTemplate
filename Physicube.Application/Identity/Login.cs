using System.Diagnostics;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using Physicube.Application.Identity.Exceptions;

namespace Physicube.Application.Identity;

public record Login(string EmailAddress, string Password) : IRequest<LoginResult>;

public class LoginHandler : IRequestHandler<Login, LoginResult>
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IdentityService _identityService;

    public LoginHandler(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
        IdentityService identityService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _identityService = identityService;
    }

    public async Task<LoginResult> Handle(Login request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.EmailAddress);
        if (user == null)
            throw new UserNotFoundException($"User with email address {request.EmailAddress} not found");

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (!result.Succeeded)
            throw new LoginFailedException("Email address or password is incorrect");

        var claims = await _userManager.GetClaimsAsync(user);

        var token = GetJwtString(user, claims);

        return new LoginResult(token);
    }
    
    private string GetJwtString(IdentityUser identity, IEnumerable<Claim> additionalClaims)
    {
        var claimsIdentity = new ClaimsIdentity(new Claim[]
        {
            new(JwtRegisteredClaimNames.Sub, identity.Email ?? throw new InvalidOperationException()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Email, identity.Email ?? throw new InvalidOperationException()),
        });
        claimsIdentity.AddClaims(additionalClaims);

        var token = _identityService.CreateSecurityToken(claimsIdentity);
        return _identityService.WriteToken(token);
    }
}


public record LoginResult(string Token);