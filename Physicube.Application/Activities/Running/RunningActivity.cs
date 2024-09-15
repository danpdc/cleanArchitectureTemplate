using Physiqube.Common.Types;

namespace Physicube.Application.Activities.Contracts;

public class RunningActivity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public TimeSpan Duration { get; set; }
    public int BurnedCalories { get; set; }
    public Distance? Distance { get; set; }
    public Pace? Pace { get; set; }
}