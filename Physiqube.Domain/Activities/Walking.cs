using Physiqube.Common.Types;
using Physiqube.Domain.Activities.Abstractions;

namespace Physiqube.Domain.Activities;

public class Walking : Activity, IDistanceActivity
{
    public Distance? Distance { get; set; }
    public int Steps { get; set; }
}