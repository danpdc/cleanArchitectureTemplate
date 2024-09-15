using Microsoft.EntityFrameworkCore;
using Physicube.Application.Abstractions.DataAbstractions;
using Physicube.Application.Athletes;
using Physiqube.Common.Types;
using Physiqube.Domain.Athletes;

namespace Physiqube.Infrastructure.Data.Repositories;

public class AthleteRepository(PhysiqubeDbContext ctx) : IAthleteRepository
{
    public async Task<Guid> RegisterAthleteAsync(string identityId, string firstName, 
        string lastName, string emailAddress, CancellationToken cancellationToken)
    {
        var athlete = Athlete.Create(identityId, firstName, lastName, emailAddress);
        ctx.Athletes.Add(athlete);
        await ctx.SaveChangesAsync(cancellationToken);
        return athlete.Id;
    }

    public async Task<AthleteProfile?> DisplayAthleteProfileAsync(CancellationToken cancellationToken)
    {
        return await ctx.Athletes
            .Include(a => a.ProfileSettings)
            .Include(a => a.Location)
            .Select(a => new AthleteProfile(
                    a.Id, a.FirstName, a.LastName, a.EmailAddress, a.Gender, a.Height, a.Weight,
                    a.ProfileSettings, a.Location
                ))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<AthleteBasicInfo?> ChangeAthleteBasicInfoAsync(string firstName, string lastName, 
        CancellationToken cancellationToken)
    {
        var athlete = await ctx.Athletes.FirstOrDefaultAsync(cancellationToken);
        if (athlete is null) return null;
        
        athlete.FirstName = firstName;
        athlete.LastName = lastName;
        await ctx.SaveChangesAsync(cancellationToken);
        return new AthleteBasicInfo(athlete.FirstName, athlete.LastName);
    }

    public async Task<Location?> ChangeAthleteLocationAsync(Location location, 
        CancellationToken cancellationToken)
    {
        var athlete = await ctx.Athletes
            .Include(a => a.Location)
            .FirstOrDefaultAsync(cancellationToken);
        if (athlete is null) return null;
        
        athlete.Location = location;
        await ctx.SaveChangesAsync(cancellationToken);
        return athlete.Location;
    }

    public async Task<AthleteBodyInfo?> ChangeAthleteBodyInfoAsync(Gender gender, Height? height, Weight? weight, 
        CancellationToken cancellationToken)
    {
        var athlete = await ctx.Athletes
            .FirstOrDefaultAsync(cancellationToken);
        if (athlete is null) return null;

        athlete.Gender = gender;
        athlete.Height = height;
        athlete.Weight = weight;
        await ctx.SaveChangesAsync(cancellationToken);
        
        return new AthleteBodyInfo(athlete.Gender, athlete.Height, athlete.Weight);
    }
}