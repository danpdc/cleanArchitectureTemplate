using System.Text.Json.Serialization;
using Physiqube.Common.Abstractions;
using Physiqube.Common.Enums;

namespace Physiqube.Common.Types;

/// <summary>
/// Represents length units in metric and imperial measurement systems
/// Supports meters (m) and feet (f) expressed as doubles.
/// In case of feet, the decimal part represents inches
/// In case of meters, the decimal part represents centimeters
/// </summary>
public class Height : IMeasurementConvertible<Height>, IEquatable<Height>, IComparable<Height>
{
    public Height(double value, MeasurementSystem system)
    {
        Value = value;
        MeasurementSystem = system;
    }
    
    // ReSharper disable once UnusedMember.Local
    public Height() {}
    
    [JsonIgnore]
    public Guid Id { get; set; }
    public double Value { get; set; }
    public MeasurementSystem MeasurementSystem { get;  set; }

    public Height ConvertFromMetricToImperial(Height source)
    {
        return MeasurementSystem == MeasurementSystem.Imperial 
            ? this 
            : new Height(source.Value * 3.281, MeasurementSystem.Imperial);
    }

    public Height ConvertFromImperialToMetric(Height source)
    {
        return MeasurementSystem == MeasurementSystem.Metric 
            ? this 
            : new Height(source.Value / 3.281, MeasurementSystem.Metric);
    }

    public Height Convert(Height source)
    {
        return source.MeasurementSystem switch
        {
            MeasurementSystem.Imperial => ConvertFromImperialToMetric(source),
            MeasurementSystem.Metric => ConvertFromMetricToImperial(source),
            _ => this
        };
    }

    public bool Equals(Height? other)
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

    public static bool operator ==(Height? left, Height? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Height? left, Height? right)
    {
        return !Equals(left, right);
    }
    
    public int CompareTo(Height? other)
    {
        //If other is not a valid object reference, this instance is greater
        if (other is null) return 1;
        return MeasurementSystem == other.MeasurementSystem 
            ? Value.CompareTo(other.Value) 
            : 1;
    }
    
    public static bool operator >(Height left, Height right)
    {
        return left.CompareTo(right) > 0;
    }

    public static bool operator <(Height left, Height right)
    {
        return left.CompareTo(right) < 0;
    }

    public static bool operator >=(Height left, Height right)
    {
        return left.CompareTo(right) >= 0;
    }

    public static bool operator <=(Height left, Height right)
    {
        return left.CompareTo(right) <= 0;
    }
    
    public override string ToString()
    {
        return MeasurementSystem switch
        {
            MeasurementSystem.Imperial => $"{Value} f",
            MeasurementSystem.Metric => $"{Value} m",
            _ => string.Empty
        };
    }
}