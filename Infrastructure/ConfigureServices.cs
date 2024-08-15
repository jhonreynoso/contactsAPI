
using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Services;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddContactsServices();
        return services;
    }

    public static IServiceCollection AddContactsServices(this IServiceCollection services)
    {
        services.AddScoped<IContactsService, ContactsService>();
        return services;
    }
    public static IServiceCollection AddDbServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        return services;
    }
}




