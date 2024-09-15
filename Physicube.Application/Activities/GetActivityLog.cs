using MediatR;
using Physicube.Application.Abstractions.DataAbstractions;
using Physicube.Application.Activities.Contracts;

namespace Physicube.Application.Activities;

public record GetActivityLog(DateTimeOffset StartDate, DateTimeOffset EndDate) : IRequest<List<ActivityLog>>;

public class GetActivityLogHandler : IRequestHandler<GetActivityLog, List<ActivityLog>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetActivityLogHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<ActivityLog>> Handle(GetActivityLog request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Activities.ShowActivityLogAsync(request.StartDate, request.EndDate);
    }
}