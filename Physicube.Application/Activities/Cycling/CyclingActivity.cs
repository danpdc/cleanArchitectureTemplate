using Physiqube.Common.Types;

namespace Physicube.Application.Activities.Cycling;

public class CyclingActivity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public TimeSpan Duration { get; set; }
    public int BurnedCalories { get; set; }
    public Distance? TripDistance { get; set; }
    public Height? ElevationGain { get; set; }
    public Height? ElevationLoss { get; set; }
    public Height? TotalElevation => GetTotalElevation();
    public Speed? AverageSpeed { get; set; }
    public Speed? MaxSpeed { get; set; }
    
    private Height? GetTotalElevation()
    {
        if (ElevationGain is null || ElevationLoss is null)
            return null;
        return new Height(ElevationGain.Value + ElevationLoss.Value, 
            ElevationGain.MeasurementSystem);
    }
}