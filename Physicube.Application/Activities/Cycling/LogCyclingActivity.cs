using MediatR;
using Physicube.Application.Abstractions.DataAbstractions;
using Physicube.Application.Identity;
using Physiqube.Common.Types;

namespace Physicube.Application.Activities.Cycling;

public record LogCyclingActivity(string Name, string? Description, DateTimeOffset CreatedAt,
    TimeSpan Duration, int BurnedCalories, 
    Distance TripDistance, Height ElevationGain, Height ElevationLoss,
    Speed AverageSpeed, Speed MaxSpeed) : IRequest<CyclingActivity>;
    
public class LogCyclingActivityHandler : IRequestHandler<LogCyclingActivity, CyclingActivity> 
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly CurrentAthlete _currentAthlete;

    public LogCyclingActivityHandler(IUnitOfWork unitOfWork, CurrentAthlete currentAthlete)
    {
        _unitOfWork = unitOfWork;
        _currentAthlete = currentAthlete;
    }

    public async Task<CyclingActivity> Handle(LogCyclingActivity request, 
        CancellationToken cancellationToken)
    {
        try
        {
            await _unitOfWork.StartTransactionAsync(cancellationToken);
            var newActivity = new Physiqube.Domain.Activities.Cycling
            {
                Name = request.Name,
                Description = request.Description,
                CreatedAt = request.CreatedAt,
                Duration = request.Duration,
                BurnedCalories = request.BurnedCalories,
                TripDistance = request.TripDistance,
                ElevationGain = request.ElevationGain,
                ElevationLoss = request.ElevationLoss,
                AverageSpeed = request.AverageSpeed,
                MaxSpeed = request.MaxSpeed,
                AthleteId = _currentAthlete.AthleteId
            };
            var result = await _unitOfWork.Activities.LogCyclingAsync(newActivity);
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