using Physiqube.Common.Types;

namespace Physiqube.Domain.Activities.Abstractions;

public interface ISpeedActivity
{
    Speed? AverageSpeed { get; set; }
    Speed? MaxSpeed { get; set; }
}