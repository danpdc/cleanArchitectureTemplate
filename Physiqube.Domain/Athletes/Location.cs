using System.Text.Json.Serialization;

namespace Physiqube.Domain.Athletes;

public class Location
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string? Country { get; set; }
    public string? Region { get; set; }
    public string? City { get; set; }
}