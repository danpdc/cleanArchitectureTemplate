using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Physicube.Application.Identity;
using Physiqube.Domain.Activities;
using Physiqube.Domain.Athletes;

namespace Physiqube.Infrastructure.Data;

public class PhysiqubeDbContext : IdentityDbContext
{
    private readonly CurrentAthlete _currentAthlete;
    public PhysiqubeDbContext(DbContextOptions opt, CurrentAthlete currentAthlete) : base(opt)
    {
        _currentAthlete = currentAthlete;
    }
    public DbSet<Athlete> Athletes { get; set; } = null!;
    public DbSet<Activity> Activities { get; set; } = null!;
    public DbSet<Cycling> CyClingActivities { get; set; } = null!;
    public DbSet<Walking> WalkingActivities { get; set; } = null!;
    public DbSet<Running> RunningActivities { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Activity>().HasQueryFilter(a => a.AthleteId == _currentAthlete.AthleteId);
        builder.Entity<Athlete>().HasQueryFilter(a => a.Id == _currentAthlete.AthleteId);
        base.OnModelCreating(builder);
    }
}