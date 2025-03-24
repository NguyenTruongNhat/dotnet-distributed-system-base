using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Query.Domain.Abstractions.Options;
using Query.Infrastructure.DependencyInjection.Options;

namespace Query.Infrastructure.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureServicesInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>(configuration.GetSection(nameof(MongoDbSettings)));

        services.AddSingleton<IMongoDbSettings>(serviceProvider =>
            serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
    }
}
