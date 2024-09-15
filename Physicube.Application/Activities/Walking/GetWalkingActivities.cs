using MediatR;
using Physicube.Application.Abstractions.DataAbstractions;
using Physicube.Application.Activities.Contracts;

namespace Physicube.Application.Activities.Walking;

public record GetWalkingActivities() : IRequest<List<WalkingActivity>>;

public class GetWalkingActivitiesHandler : IRequestHandler<GetWalkingActivities, List<WalkingActivity>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetWalkingActivitiesHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<WalkingActivity>> Handle(GetWalkingActivities request, 
        CancellationToken cancellationToken)
    {
        return await _unitOfWork.Activities.GetWalkingActivitiesAsync();
    }
}