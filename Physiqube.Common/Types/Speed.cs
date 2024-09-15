using System.Text.Json.Serialization;
using Physiqube.Common.Abstractions;
using Physiqube.Common.Enums;

namespace Physiqube.Common.Types;

/// <summary>
/// Represents speed units in metric and imperial systems.
/// Supports kmh and mph.
/// </summary>
public class Speed : IMeasurementConvertible<Speed>, IEquatable<Speed>, IComparable<Speed>
{
    public Speed(double value, MeasurementSystem system)
    {
        Value = value;
        MeasurementSystem = system;
    }
    
    public Speed() {}
    
    [JsonIgnore]
    public Guid Id { get; set; }
    public double Value { get;  set; }
    public MeasurementSystem MeasurementSystem { get;  set; }

    public Speed ConvertFromMetricToImperial(Speed source)
    {
        return MeasurementSystem == MeasurementSystem.Imperial 
            ? this 
            : new Speed(source.Value / 1.609, MeasurementSystem.Imperial);
    }

    public Speed ConvertFromImperialToMetric(Speed source)
    {
        return MeasurementSystem == MeasurementSystem.Metric 
            ? this 
            : new Speed(source.Value * 1.609, MeasurementSystem.Metric);
    }

    public Speed Convert(Speed source)
    {
        return source.MeasurementSystem switch
        {
            MeasurementSystem.Imperial => ConvertFromImperialToMetric(source),
            MeasurementSystem.Metric => ConvertFromMetricToImperial(source),
            _ => this
        };
    }

    public bool Equals(Speed? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value.Equals(other.Value) && MeasurementSystem == other.MeasurementSystem;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Height)obj);
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Value, (int)MeasurementSystem);
    }
    
    public static bool operator ==(Speed? left, Speed? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Speed? left, Speed? right)
    {
        return !Equals(left, right);
    }
    
    public int CompareTo(Speed? other)
    {
        //If other is not a valid object reference, this instance is greater
        if (other is null) return 1;
        return MeasurementSystem == other.MeasurementSystem 
            ? Value.CompareTo(other.Value) 
            : 1;
    }
    
    public static bool operator >(Speed left, Speed right)
    {
        return left.CompareTo(right) > 0;
    }

    public static bool operator <(Speed left, Speed right)
    {
        return left.CompareTo(right) < 0;
    }

    public static bool operator >=(Speed left, Speed right)
    {
        return left.CompareTo(right) >= 0;
    }

    public static bool operator <=(Speed left, Speed right)
    {
        return left.CompareTo(right) <= 0;
    }

    public override string ToString()
    {
        return MeasurementSystem switch
        {
            MeasurementSystem.Metric => $"{Value} km/h",
            MeasurementSystem.Imperial => $"{Value} mph",
            _ => $"{Value} km/h"
        };
    }
}