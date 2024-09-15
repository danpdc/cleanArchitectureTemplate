using System.Text.Json.Serialization;
using Physiqube.Common.Abstractions;
using Physiqube.Common.Enums;

namespace Physiqube.Common.Types;

/// <summary>
/// Represents distance units in metric and imperial measurement systems
/// Supports kilometers (km) in the metric systems and miles (m) in the imperial system
/// </summary>
public class Distance : IMeasurementConvertible<Distance>, IEquatable<Distance>, IComparable<Distance>
{
    public Distance(double value, MeasurementSystem measurementSystem)
    {
        Value = value;
        MeasurementSystem = measurementSystem;
    }

    public Distance() {}
    
    [JsonIgnore]
    public Guid Id { get; set; }
    public double Value { get; set; }
    public MeasurementSystem MeasurementSystem { get;  set; }
    
    public Distance ConvertFromMetricToImperial(Distance source)
    {
        return MeasurementSystem == MeasurementSystem.Imperial 
            ? this 
            : new Distance(Value * 0.621371, MeasurementSystem.Imperial);
    }

    public Distance ConvertFromImperialToMetric(Distance source)
    {
        return MeasurementSystem == MeasurementSystem.Metric 
            ? this 
            : new Distance(Value * 1.609344, MeasurementSystem.Metric);
    }

    public Distance Convert(Distance source)
    {
        return source.MeasurementSystem switch
        {
            MeasurementSystem.Imperial => ConvertFromImperialToMetric(source),
            MeasurementSystem.Metric => ConvertFromMetricToImperial(source),
            _ => this
        };
    }

    public bool Equals(Distance? other)
    {
        if (other is null) return false;
        
        //If the same measurement system, we just check the values for equality
        if (MeasurementSystem == other.MeasurementSystem) return Value.Equals(other.Value);
        
        //If different measurement systems, we first convert to the same measurement system 
        //and then we check the values for equality
        var convertedDistance = MeasurementSystem switch 
        { 
            MeasurementSystem.Imperial => ConvertFromMetricToImperial(other),
            MeasurementSystem.Metric => ConvertFromImperialToMetric(other),
            _ => this
        };

        return Value.Equals(convertedDistance.Value);
    }
    
    public override bool Equals(object? obj)
    {
        return Equals(obj as Distance);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, (int)MeasurementSystem);
    }

    public int CompareTo(Distance? other)
    {
        //If other is not a valid object reference, this instance is greater
        if (other is null) return 1;

        if (MeasurementSystem == other.MeasurementSystem) return Value.CompareTo(other.Value);
        
        var convertedDistance = MeasurementSystem switch 
        { 
            MeasurementSystem.Imperial => ConvertFromMetricToImperial(other),
            MeasurementSystem.Metric => ConvertFromImperialToMetric(other),
            _ => this
        };

        return Value.CompareTo(convertedDistance.Value);
    }

    public static bool operator ==(Distance left, Distance right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Distance left, Distance right)
    {
        return !left.Equals(right);
    }

    public static bool operator >(Distance left, Distance right)
    {
        return left.CompareTo(right) > 0;
    }

    public static bool operator <(Distance left, Distance right)
    {
        return left.CompareTo(right) < 0;
    }

    public static bool operator >=(Distance left, Distance right)
    {
        return left.CompareTo(right) >= 0;
    }

    public static bool operator <=(Distance left, Distance right)
    {
        return left.CompareTo(right) <= 0;
    }

    public override string ToString()
    {
        return MeasurementSystem switch
        {
            MeasurementSystem.Imperial => $"{Value} mi",
            MeasurementSystem.Metric => $"{Value} km",
            _ => $"{Value} km"
        };
    }
}