namespace Physicube.Application.Identity;

public class JwtSettings
{
    public string? SigningKey { get; set; }
    public string? Issuer { get; set; }
    public string[]? Audiences { get; set; }
}