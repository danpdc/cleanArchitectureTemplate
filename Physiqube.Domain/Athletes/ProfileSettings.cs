using Physiqube.Common.Enums;

namespace Physiqube.Domain.Athletes;

public class ProfileSettings
{
    public Guid Id { get; set; }
    public MeasurementSystem PreferredMeasurementSystem { get; set; }
    public string? PreferredTimezone { get; set; }
}