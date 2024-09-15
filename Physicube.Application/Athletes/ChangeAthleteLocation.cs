using MediatR;
using Physicube.Application.Abstractions.DataAbstractions;
using Physiqube.Domain.Athletes;

namespace Physicube.Application.Athletes;

public record ChangeAthleteLocation(Location Location) : IRequest<Location?>;

public class ChangeAthleteLocationHandler : IRequestHandler<ChangeAthleteLocation, Location?>
{
    private readonly IUnitOfWork _unitOfWork;

    public ChangeAthleteLocationHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Location?> Handle(ChangeAthleteLocation request, 
        CancellationToken cancellationToken)
    {
        return await _unitOfWork.Athletes
            .ChangeAthleteLocationAsync(request.Location, cancellationToken);
    }
}