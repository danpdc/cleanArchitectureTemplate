using MediatR;
using Physicube.Application.Abstractions.DataAbstractions;
using Physicube.Application.Activities.Contracts;

namespace Physicube.Application.Activities.Running;

public record GetRunningActivities() : IRequest<List<RunningActivity>>;
public class GetRunningActivitiesHandler : IRequestHandler<GetRunningActivities, List<RunningActivity>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRunningActivitiesHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<RunningActivity>> Handle(GetRunningActivities request, 
        CancellationToken cancellationToken)
    {
        return await _unitOfWork.Activities.GetRunningActivitiesAsync();
    }
}