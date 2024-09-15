using MediatR;
using Physicube.Application.Abstractions.DataAbstractions;

namespace Physicube.Application.Athletes;

public record ChangeAthleteBasicInfo(string FirstName, string LastName) : IRequest<AthleteBasicInfo?>;

public class ChangeAthleteBasicInfoHandler : IRequestHandler<ChangeAthleteBasicInfo, AthleteBasicInfo?>
{
    private readonly IUnitOfWork _unitOfWork;

    public ChangeAthleteBasicInfoHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AthleteBasicInfo?> Handle(ChangeAthleteBasicInfo request, 
        CancellationToken cancellationToken)
    {
        return await _unitOfWork
            .Athletes.ChangeAthleteBasicInfoAsync(request.FirstName, request.LastName, cancellationToken);
    }
}

public record AthleteBasicInfo(string FirstName, string LastName);