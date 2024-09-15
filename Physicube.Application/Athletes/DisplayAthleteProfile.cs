using MediatR;
using Physicube.Application.Abstractions.DataAbstractions;
using Physiqube.Common.Types;
using Physiqube.Domain.Athletes;

namespace Physicube.Application.Athletes;

public record DisplayAthleteProfile() : IRequest<AthleteProfile?>;

public class DisplayAthleteProfileHandler : IRequestHandler<DisplayAthleteProfile, AthleteProfile?>
{
    private readonly IUnitOfWork _unitOfWork;

    public DisplayAthleteProfileHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<AthleteProfile?> Handle(DisplayAthleteProfile request, 
        CancellationToken cancellationToken)
    {
        return await _unitOfWork.Athletes.DisplayAthleteProfileAsync(cancellationToken);
    }
}

public record AthleteProfile(Guid Id, string FirstName, string LastName, string Email, Gender Gender,
    Height? Height, Weight? Weight, ProfileSettings? ProfileSettings, Location? Location);