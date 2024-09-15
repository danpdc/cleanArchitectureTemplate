using Physiqube.Common.Types;
using Physiqube.Domain.Activities.Abstractions;

namespace Physiqube.Domain.Activities;

public class Cycling : Activity, IElevationActivity, ISpeedActivity, IDistanceActivity
{
    public Distance? TripDistance { get; set; }
    public Height? ElevationGain { get; set; }
    public Height? ElevationLoss { get; set; }
    public Height? TotalElevation => GetTotalElevation();
    public Speed? AverageSpeed { get; set; }
    public Speed? MaxSpeed { get; set; }
    public Distance? Distance { get; set; }
    
    private Height? GetTotalElevation()
    {
        if (ElevationGain is null || ElevationLoss is null)
            return null;
        return new Height(ElevationGain.Value + ElevationLoss.Value, 
            ElevationGain.MeasurementSystem);
    }
    
}