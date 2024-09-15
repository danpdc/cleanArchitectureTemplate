using Microsoft.Extensions.DependencyInjection;
using Physicube.Application.Abstractions.DataAbstractions;
using Physicube.Application.Identity;

namespace Physicube.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(IAthleteRepository).Assembly);
        });
        services.AddSingleton<IdentityService>();
        services.AddScoped<CurrentAthlete>();
        return services;
    }
}