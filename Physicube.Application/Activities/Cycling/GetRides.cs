using MediatR;
using Physicube.Application.Abstractions.DataAbstractions;

namespace Physicube.Application.Activities.Cycling;

public record GetRides() : IRequest<List<CyclingActivity>>;

public class GetRidesHandler : IRequestHandler<GetRides, List<CyclingActivity>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRidesHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<CyclingActivity>> Handle(GetRides request, 
        CancellationToken cancellationToken)
    {
        return await _unitOfWork.Activities.GetRidesAsync();
    }
}