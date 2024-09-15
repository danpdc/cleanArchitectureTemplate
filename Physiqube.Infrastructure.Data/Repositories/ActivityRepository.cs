using Microsoft.EntityFrameworkCore;
using Physicube.Application.Abstractions.DataAbstractions;
using Physicube.Application.Activities;
using Physicube.Application.Activities.Contracts;
using Physicube.Application.Activities.Cycling;
using Physiqube.Domain.Activities;

namespace Physiqube.Infrastructure.Data.Repositories;

public class ActivityRepository(PhysiqubeDbContext context) : IActivityRepository
{

    public async Task<WalkingActivity> LogWalkingAsync(Walking newActivity)
    {
        context.WalkingActivities.Add(newActivity);
        await context.SaveChangesAsync();
        return new WalkingActivity
        {
            Id = newActivity.Id,
            WalkedDistance = newActivity.Distance,
            Steps = newActivity.Steps,
            Name = newActivity.Name,
            Description = newActivity.Description ?? string.Empty,
            CreatedAt = newActivity.CreatedAt,
            UpdatedAt = newActivity.UpdatedAt,
            Duration = newActivity.Duration,
            BurnedCalories = newActivity.BurnedCalories
        };
    }

    public async Task<List<WalkingActivity>> GetWalkingActivitiesAsync()
    {
        return await context.WalkingActivities
            .Select(wa => new WalkingActivity
            {
                Id = wa.Id,
                WalkedDistance = wa.Distance,
                Steps = wa.Steps,
                Name = wa.Name,
                Description = wa.Description ?? string.Empty,
                CreatedAt = wa.CreatedAt,
                UpdatedAt = wa.UpdatedAt,
                Duration = wa.Duration,
                BurnedCalories = wa.BurnedCalories
            })
            .ToListAsync();
    }

    public async Task<RunningActivity> LogRunAsync(Running newActivity)
    {
        context.RunningActivities.Add(newActivity);
        await context.SaveChangesAsync();
        return new RunningActivity
        {
            Id = newActivity.Id,
            Distance = newActivity.Distance,
            Pace = newActivity.Pace,
            Name = newActivity.Name,
            Description = newActivity.Description ?? string.Empty,
            CreatedAt = newActivity.CreatedAt,
            UpdatedAt = newActivity.UpdatedAt,
            Duration = newActivity.Duration,
            BurnedCalories = newActivity.BurnedCalories
        };
    }

    public async Task<List<RunningActivity>> GetRunningActivitiesAsync()
    {
        return await context.RunningActivities
            .Select(ra => new RunningActivity
            {
                Id = ra.Id,
                Distance = ra.Distance,
                Pace = ra.Pace,
                Name = ra.Name,
                Description = ra.Description ?? string.Empty,
                CreatedAt = ra.CreatedAt,
                UpdatedAt = ra.UpdatedAt,
                Duration = ra.Duration,
                BurnedCalories = ra.BurnedCalories
            })
            .ToListAsync();
    }

    public async Task<List<ActivityLog>> ShowActivityLogAsync(DateTimeOffset startDate, DateTimeOffset endDate)
    {
        return await context.Activities
            .Where(al => al.CreatedAt >= startDate && al.CreatedAt <= endDate)
            .Select(a => new ActivityLog
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description ?? string.Empty,
                CreatedAt = a.CreatedAt,
                UpdatedAt = a.UpdatedAt,
                Duration = a.Duration,
                BurnedCalories = a.BurnedCalories,
                Activity = a.GetType().Name
            })
            .ToListAsync();
    }

    public async Task<CyclingActivity> LogCyclingAsync(Cycling newActivity)
    {
        context.CyClingActivities.Add(newActivity);
        await context.SaveChangesAsync();
        return new CyclingActivity
        {
            Id = newActivity.Id,
            TripDistance = newActivity.Distance,
            Name = newActivity.Name,
            Description = newActivity.Description ?? string.Empty,
            CreatedAt = newActivity.CreatedAt,
            UpdatedAt = newActivity.UpdatedAt,
            Duration = newActivity.Duration,
            BurnedCalories = newActivity.BurnedCalories,
            MaxSpeed = newActivity.MaxSpeed,
            AverageSpeed = newActivity.AverageSpeed,
            ElevationGain = newActivity.ElevationGain,
            ElevationLoss = newActivity.ElevationLoss
        };
    }

    public async Task<List<CyclingActivity>> GetRidesAsync()
    {
        return await context.CyClingActivities
            .Select(ca => new CyclingActivity
            {
                Id = ca.Id,
                TripDistance = ca.Distance,
                Name = ca.Name,
                Description = ca.Description ?? string.Empty,
                CreatedAt = ca.CreatedAt,
                UpdatedAt = ca.UpdatedAt,
                Duration = ca.Duration,
                BurnedCalories = ca.BurnedCalories,
                MaxSpeed = ca.MaxSpeed,
                AverageSpeed = ca.AverageSpeed,
                ElevationGain = ca.ElevationGain,
                ElevationLoss = ca.ElevationLoss
            })
            .ToListAsync();
    }
}