using Physicube.Application.Activities;
using Physicube.Application.Activities.Contracts;
using Physicube.Application.Activities.Cycling;
using Physiqube.Domain.Activities;

namespace Physicube.Application.Abstractions.DataAbstractions;

public interface IActivityRepository
{
    Task<WalkingActivity> LogWalkingAsync(Walking newActivity);
    Task<List<WalkingActivity>> GetWalkingActivitiesAsync();
    Task<RunningActivity> LogRunAsync(Running newActivity);
    Task<List<RunningActivity>> GetRunningActivitiesAsync();
    Task<List<ActivityLog>> ShowActivityLogAsync(DateTimeOffset startDate, DateTimeOffset endDate);
    Task<CyclingActivity> LogCyclingAsync(Cycling newActivity);
    Task<List<CyclingActivity>> GetRidesAsync();
}