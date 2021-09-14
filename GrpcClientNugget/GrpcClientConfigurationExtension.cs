namespace GrpcClientNugget;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
/// <summary>
/// Class used for dependency Injection
/// </summary>
public static class GrpcClientConfigurationExtension
{
    /// <summary>
    /// Method for dependency injection. Called in program.cs with configuration parameter
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddGreeterClientServices(this IServiceCollection services, IConfiguration configuration)
    {
        GrpcClientConfiguration grpcClientConfiguration = new();
        configuration.GetSection(GrpcClientConfiguration.Name).Bind(grpcClientConfiguration);

        services.AddSingleton(grpcClientConfiguration);
        services.AddScoped<GreeterClientService>();
        return services;
    }
}

