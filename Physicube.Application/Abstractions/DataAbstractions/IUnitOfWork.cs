namespace Physicube.Application.Abstractions.DataAbstractions;

public interface IUnitOfWork
{
    IActivityRepository Activities { get; }
    IAthleteRepository Athletes { get; }
    Task StartTransactionAsync(CancellationToken cancellationToken);
    Task SubmitTransactionAsync(CancellationToken cancellationToken);
    Task RevertTransactionAsync(CancellationToken cancellationToken);
}