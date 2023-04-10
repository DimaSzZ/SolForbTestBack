using Domain.Interface;
using Domain.Interface.Repositories;
using Infrastructure.Parsistence.PgDbContext;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DepInj;

public static class DepInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDb(configuration);
        services.AddRepositories();
        return services;
    }
    private static IServiceCollection AddDb(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<PgDbContext>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        return services;
    }
    private static IServiceCollection AddRepositories(
        this IServiceCollection services)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProviderRepository, ProviderRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        return services;
    }
}