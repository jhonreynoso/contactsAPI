using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;


public static class ConfigureServices
{

    public static IServiceCollection AddWebApiServices(this IServiceCollection services)
    {
        //for demo.. here whould be services registered from web api
        return services;
    }
}

