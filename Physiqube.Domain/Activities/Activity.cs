using Physiqube.Domain.Athletes;

namespace Physiqube.Domain.Activities;

public class Activity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public TimeSpan Duration { get; set; }
    public int BurnedCalories { get; set; }
    public Guid AthleteId { get; set; }
    public Athlete? Athlete { get; set; }
}