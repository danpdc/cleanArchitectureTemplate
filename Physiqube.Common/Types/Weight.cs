using System.Text.Json.Serialization;
using Physiqube.Common.Abstractions;
using Physiqube.Common.Enums;

namespace Physiqube.Common.Types;

public class Weight : IMeasurementConvertible<Weight>, IEquatable<Weight>, IComparable<Weight>
{
    public Weight(double value, MeasurementSystem system)
    {
        Value = value;
        MeasurementSystem = system;
    }
    
    public Weight() {}
    
    [JsonIgnore]
    public Guid Id { get; set; }
    public double Value { get;  set; }
    public MeasurementSystem MeasurementSystem { get;  set; }
    
    public Weight ConvertFromMetricToImperial(Weight source)
    {
        return MeasurementSystem == MeasurementSystem.Imperial 
            ? this 
            : new Weight(source.Value * 2.205, MeasurementSystem.Imperial);
    }

    public Weight ConvertFromImperialToMetric(Weight source)
    {
        return MeasurementSystem == MeasurementSystem.Metric 
            ? this 
            : new Weight(source.Value / 2.205, MeasurementSystem.Metric);
    }

    public Weight Convert(Weight source)
    {
        return source.MeasurementSystem switch
        {
            MeasurementSystem.Imperial => ConvertFromImperialToMetric(source),
            MeasurementSystem.Metric => ConvertFromMetricToImperial(source),
            _ => this
        };
    }

    public bool Equals(Weight? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value.Equals(other.Value) && MeasurementSystem == other.MeasurementSystem;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Weight)obj);
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Value, (int)MeasurementSystem);
    }
    
    public static bool operator ==(Weight? left, Weight? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Weight? left, Weight? right)
    {
        return !Equals(left, right);
    }
    
    public int CompareTo(Weight? other)
    {
        //If other is not a valid object reference, this instance is greater
        if (other is null) return 1;
        return MeasurementSystem == other.MeasurementSystem 
            ? Value.CompareTo(other.Value) 
            : 1;
    }
    
    public static bool operator >(Weight left, Weight right)
    {
        return left.CompareTo(right) > 0;
    }

    public static bool operator <(Weight left, Weight right)
    {
        return left.CompareTo(right) < 0;
    }

    public static bool operator >=(Weight left, Weight right)
    {
        return left.CompareTo(right) >= 0;
    }

    public static bool operator <=(Weight left, Weight right)
    {
        return left.CompareTo(right) <= 0;
    }
    
    public override string ToString()
    {
        return MeasurementSystem switch 
        {
            MeasurementSystem.Imperial => $"{Value} lbs",
            MeasurementSystem.Metric => $"{Value} kg",
            _ => $"{Value} kg"
        };
    }
}