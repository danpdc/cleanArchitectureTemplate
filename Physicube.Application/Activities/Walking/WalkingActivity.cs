using Physiqube.Common.Types;

namespace Physicube.Application.Activities.Contracts;

public class WalkingActivity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public TimeSpan Duration { get; set; }
    public int BurnedCalories { get; set; }
    public Distance? WalkedDistance { get; set; }
    public int Steps { get; set; }
}