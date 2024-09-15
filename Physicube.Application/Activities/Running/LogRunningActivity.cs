using MediatR;
using Physicube.Application.Abstractions.DataAbstractions;
using Physicube.Application.Activities.Contracts;
using Physicube.Application.Identity;
using Physiqube.Common.Types;

namespace Physicube.Application.Activities.Running;

public record LogRunningActivity(string Name, string? Description,
    DateTimeOffset CreatedAt, TimeSpan Duration, int BurnedCalories, Distance Distance,
    Pace Pace) : IRequest<RunningActivity>;

public class LogRunningActivityHandler : IRequestHandler<LogRunningActivity, RunningActivity>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly CurrentAthlete _currentAthlete;

    public LogRunningActivityHandler(IUnitOfWork unitOfWork, CurrentAthlete currentAthlete)
    {
        _unitOfWork = unitOfWork;
        _currentAthlete = currentAthlete;
    }
    
    public async Task<RunningActivity> Handle(LogRunningActivity request, 
        CancellationToken cancellationToken)
    {

        try
        {
            await _unitOfWork.StartTransactionAsync(cancellationToken);
            var newActivity = new Physiqube.Domain.Activities.Running
            {
                Name = request.Name,
                Description = request.Description,
                CreatedAt = request.CreatedAt,
                Duration = request.Duration,
                BurnedCalories = request.BurnedCalories,
                Distance = request.Distance,
                Pace = request.Pace,
                AthleteId = _currentAthlete.AthleteId
            };
            var result = await _unitOfWork.Activities.LogRunAsync(newActivity);
            await _unitOfWork.SubmitTransactionAsync(cancellationToken);
            return result;
        }
        catch (Exception)
        {
            await _unitOfWork.RevertTransactionAsync(cancellationToken);
            throw;
        }
    }
}

