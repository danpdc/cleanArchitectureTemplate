using Physicube.Application.Athletes;
using Physiqube.Common.Types;
using Physiqube.Domain.Athletes;

namespace Physicube.Application.Abstractions.DataAbstractions;

public interface IAthleteRepository
{
    Task<Guid> RegisterAthleteAsync(string identityId, string firstName, string lastName, 
        string emailAddress, CancellationToken cancellationToken);
    Task<AthleteProfile?> DisplayAthleteProfileAsync(CancellationToken cancellationToken);
    Task<AthleteBasicInfo?> ChangeAthleteBasicInfoAsync(string firstName, string lastName, 
        CancellationToken cancellationToken);
    Task<Location?> ChangeAthleteLocationAsync(Location location, CancellationToken cancellationToken);
    Task<AthleteBodyInfo?> ChangeAthleteBodyInfoAsync(Gender gender, Height? height, Weight? weight, 
        CancellationToken cancellationToken);
}