using Physiqube.Common.Types;

namespace Physiqube.Domain.Activities.Abstractions;

public interface IElevationActivity
{
    public Height? ElevationGain { get; set; }
    public Height? ElevationLoss { get; set; }
    public Height? TotalElevation { get; }
}