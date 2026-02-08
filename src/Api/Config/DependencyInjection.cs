using Api.Interfaces;
using Api.Repositories;

namespace Api.Config;

public static class DependencyInjection
{
    public static void AddGlobalDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDbContext, DbContext>();
        services.AddScoped<IPlayerRepository, PlayerRepository>();
    }
}