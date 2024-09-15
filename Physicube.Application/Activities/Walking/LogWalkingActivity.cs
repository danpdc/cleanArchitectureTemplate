using MediatR;
using Physicube.Application.Abstractions.DataAbstractions;
using Physicube.Application.Activities.Contracts;
using Physicube.Application.Identity;
using Physiqube.Common.Types;

namespace Physicube.Application.Activities.Walking;

public record LogWalkingActivity(string Name, string? Description, TimeSpan Duration, 
    int BurnedCalories, Distance? WalkedDistance, int Steps) : IRequest<WalkingActivity>;

/// <inheritdoc />
public class LogWalkingActivityHandler
    : IRequestHandler<LogWalkingActivity, WalkingActivity>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly CurrentAthlete _currentAthlete;

    public LogWalkingActivityHandler(IUnitOfWork unitOfWork, CurrentAthlete currentAthlete)
    {
        _unitOfWork = unitOfWork;
        _currentAthlete = currentAthlete;
    }
    public async Task<WalkingActivity> Handle(LogWalkingActivity request, CancellationToken cancellationToken)
    {
        try
        {
            var newActivity = new Physiqube.Domain.Activities.Walking
            {
                Name = request.Name,
                Description = request.Description,
                CreatedAt = DateTimeOffset.Now.LocalDateTime,
                Duration = request.Duration,
                BurnedCalories = request.BurnedCalories,
                Distance = request.WalkedDistance,
                Steps = request.Steps,
                AthleteId = _currentAthlete.AthleteId
            
            };
            await _unitOfWork.StartTransactionAsync(cancellationToken);
            var result = await _unitOfWork.Activities.LogWalkingAsync(newActivity);
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
