using Physicube.Application.Abstractions.DataAbstractions;

namespace Physiqube.Infrastructure.Data;

public class PhysiqubeUoW : IUnitOfWork
{
    private readonly PhysiqubeDbContext _context;

    public PhysiqubeUoW(PhysiqubeDbContext context, IActivityRepository activities, 
        IAthleteRepository athletes)
    {
        _context = context;
        Activities = activities;
        Athletes = athletes;
    }

    public IActivityRepository Activities { get; }
    public IAthleteRepository Athletes { get; }

    public async Task StartTransactionAsync(CancellationToken cancellationToken)
    {
        await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task SubmitTransactionAsync(CancellationToken cancellationToken)
    {
        await _context.Database.CommitTransactionAsync(cancellationToken);
    }

    public async Task RevertTransactionAsync(CancellationToken cancellationToken)
    {
        await _context.Database.RollbackTransactionAsync(cancellationToken);
    }
}