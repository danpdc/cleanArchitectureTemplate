namespace Physiqube.Common.Abstractions;

public interface IMeasurementConvertible<T> where T : IMeasurementConvertible<T>
{
    /// <summary>
    /// Converts a measurement unit from the metric to the imperial measurement system
    /// </summary>
    /// <param name="source">The measurement unit to be converted from the metric to the imperial system</param>
    /// <returns cref="IMeasurementConvertible{T}">The converted measurement unit in the imperial measurement system</returns>
    T ConvertFromMetricToImperial(T source);
    
    /// <summary>
    /// Converts a measurement unit from the metric to the imperial measurement system
    /// </summary>
    /// <param name="source">The measurement unit that needs to be converted to the metric system</param>
    /// <returns cref="IMeasurementConvertible{T}">The converted measurement unit in the metric system</returns>
    T ConvertFromImperialToMetric(T source);

    /// <summary>
    /// Converts a measurement unit from one measurement system to the other.
    /// It automatically detects the measurement unit and performs a conversion to the other one
    /// </summary>
    /// <param name="source">The measurement unit that needs to be converted</param>
    /// <returns cref="IMeasurementConvertible{T}">The converted measurement unit</returns>
    T Convert(T source);

}