using MediatR;
using Physicube.Application.Abstractions.DataAbstractions;
using Physiqube.Common.Types;
using Physiqube.Domain.Athletes;

namespace Physicube.Application.Athletes;

public record ChangeAthleteBodyInfo(Gender Gender, Height? Height, Weight? Weight) : IRequest<AthleteBodyInfo?>;

public class ChangeAthleteBodyInfoHandler : IRequestHandler<ChangeAthleteBodyInfo, AthleteBodyInfo?>
{
    private readonly IUnitOfWork _unitOfWork;

    public ChangeAthleteBodyInfoHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AthleteBodyInfo?> Handle(ChangeAthleteBodyInfo request,
        CancellationToken cancellationToken)
    {
        return await _unitOfWork.Athletes
            .ChangeAthleteBodyInfoAsync(request.Gender, request.Height, request.Weight, cancellationToken);
    }
}

public record AthleteBodyInfo(Gender Gender, Height? Height, Weight? Weight);