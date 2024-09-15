using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Physicube.Application.Identity;

public class CurrentAthlete
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentAthlete(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public Guid AthleteId => Guid.Parse(_httpContextAccessor.HttpContext?
        .User.FindFirstValue("AthleteId") ?? default(Guid).ToString());
    public string IdentityId => _httpContextAccessor.HttpContext?
        .User.FindFirstValue("IdentityId") ?? string.Empty;
}