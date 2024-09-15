using Physiqube.Common.Types;
using Physiqube.Domain.Activities.Abstractions;

namespace Physiqube.Domain.Activities;

public class Running : Activity, IDistanceActivity
{
    public Distance? Distance { get; set; }
    public Pace? Pace { get; set; }
}
