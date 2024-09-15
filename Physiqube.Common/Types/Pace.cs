using System.Text.Json.Serialization;
using Physiqube.Common.Abstractions;
using Physiqube.Common.Enums;

namespace Physiqube.Common.Types;

public class Pace
{
    public Pace(TimeSpan value, MeasurementSystem measurementSystem)
    {
        Value = value;
        MeasurementSystem = measurementSystem;
    }

    public Pace()
    {
        
    }

    [JsonIgnore]
    public Guid Id { get; set; }
    public TimeSpan Value { get;  set; }
    public MeasurementSystem MeasurementSystem { get;  set; }
    
    public override string ToString()
    {
        return MeasurementSystem switch
        {
            MeasurementSystem.Imperial => $"{Value.Minutes}:{Value.Seconds} /mile",
            MeasurementSystem.Metric => $"{Value.Minutes}:{Value.Seconds} /km",
            _ => string.Empty
        };
    }
}