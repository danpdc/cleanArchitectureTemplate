namespace Physicube.Application.Activities;

public class ActivityLog
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public TimeSpan Duration { get; set; }
    public int BurnedCalories { get; set; }
    public required string Activity { get; set; }
}