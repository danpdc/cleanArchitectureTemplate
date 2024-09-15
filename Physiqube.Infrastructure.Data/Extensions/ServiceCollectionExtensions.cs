using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Physicube.Application.Abstractions.DataAbstractions;
using Physiqube.Infrastructure.Data.Repositories;

namespace Physiqube.Infrastructure.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PhysiqubeDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
        });

        services.AddScoped<IAthleteRepository, AthleteRepository>();
        services.AddScoped<IActivityRepository, ActivityRepository>();
        services.AddScoped<IUnitOfWork, PhysiqubeUoW>();

        return services;
    }
}