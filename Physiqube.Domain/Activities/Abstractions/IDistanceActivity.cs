using Physiqube.Common.Types;

namespace Physiqube.Domain.Activities.Abstractions;

public interface IDistanceActivity
{
    Distance? Distance { get; set; }
}