using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using Physicube.Application.Abstractions.DataAbstractions;
using Physicube.Application.Identity.Exceptions;
using Physiqube.Domain.Athletes;

namespace Physicube.Application.Identity;

public record Register(
    string EmailAddress,
    string FirstName,
    string LastName,
    string Password) : IRequest<RegistrationResult>;

public class RegisterHandler : IRequestHandler<Register, RegistrationResult>
{
    private readonly IUnitOfWork _uow;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IdentityService _identityService;

    public RegisterHandler(IUnitOfWork uow, UserManager<IdentityUser> userManager,
        IdentityService identityService)
    {
        _uow = uow;
        _userManager = userManager;
        _identityService = identityService;
    }
    public async Task<RegistrationResult> Handle(Register request, CancellationToken cancellationToken)
    {
        try
        {
            await _uow.StartTransactionAsync(cancellationToken);
            var identity = await CreateIdentityUserAsync(request, cancellationToken);
            var athlete = await CreateAthleteAsync(request, identity, cancellationToken);
            var additionalClaims = GetIdentityAndAthleteClaims(identity, athlete);
            await _userManager.AddClaimsAsync(identity, additionalClaims);
            await _uow.SubmitTransactionAsync(cancellationToken);
            var token = GetJwtString(identity, additionalClaims);

            return new RegistrationResult(identity.Id, athlete.Id, identity.Email!, athlete.FirstName, 
                athlete.LastName, token);
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            await _uow.RevertTransactionAsync(cancellationToken);
            throw;
        }
    }
    
    private async Task<IdentityUser> CreateIdentityUserAsync(Register request, 
        CancellationToken cancellationToken)
    {
        var identity = new IdentityUser {Email = request.EmailAddress, UserName = request.EmailAddress};
        var createdIdentity = await _userManager.CreateAsync(identity, request.Password);
        if (!createdIdentity.Succeeded)
            throw new UserRegistrationFailedException(createdIdentity.Errors.First().Description);
        return identity;
    }

    private async Task<Athlete> CreateAthleteAsync(Register request, IdentityUser identity,
        CancellationToken cancellationToken)
    {
        var athlete = new Athlete
        {
            IdentityId = identity.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            EmailAddress = request.EmailAddress
        };
        athlete.Id = await _uow.Athletes.RegisterAthleteAsync(identity.Id, request.FirstName,
            request.LastName, request.EmailAddress, cancellationToken);
        return athlete;
    }
    
    private string GetJwtString(IdentityUser identity, IEnumerable<Claim> additionalClaims)
    {
        var claimsIdentity = new ClaimsIdentity(new Claim[]
        {
            new(JwtRegisteredClaimNames.Sub, identity.Email ?? throw new InvalidOperationException()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Email, identity.Email),
        });
        claimsIdentity.AddClaims(additionalClaims);

        var token = _identityService.CreateSecurityToken(claimsIdentity);
        return _identityService.WriteToken(token);
    }

    private List<Claim> GetIdentityAndAthleteClaims(IdentityUser identity, Athlete athlete)
    {
        return new List<Claim>
        {
            new("IdentityId", identity.Id),
            new("AthleteId", athlete.Id.ToString()),
            new("EmailAddress", identity.Email!),
            new("FirstName", athlete.FirstName),
            new("LastName", athlete.LastName)
        };
    }
}

public record RegistrationResult(string IdentityId, Guid AthleteId, string EmailAddress, string FirstName, 
    string LastName, string Token);