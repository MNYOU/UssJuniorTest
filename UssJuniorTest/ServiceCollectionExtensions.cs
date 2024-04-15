using Sieve.Services;
using UssJuniorTest.Application.Services;
using UssJuniorTest.Application.Sieve;
using UssJuniorTest.Core;
using UssJuniorTest.Core.Models;
using UssJuniorTest.Infrastructure.Repositories;
using UssJuniorTest.Infrastructure.Store;

namespace UssJuniorTest;

public static class ServiceCollectionExtensions
{
    public static void RegisterAppServices(this IServiceCollection services)
    {
        services.AddSingleton<IStore, InMemoryStore>();

        services.AddScoped<IRepository<Car>, CarRepository>();
        services.AddScoped<IRepository<Person>, PersonRepository>();
        services.AddScoped<IRepository<DriveLog>, DriverLogRepository>();

        services.AddScoped<IDriverReportsGenerator, DriverReportsGenerator>();
        
        services.AddScoped<ISieveProcessor, AppSieveProcessor>();
    }
}