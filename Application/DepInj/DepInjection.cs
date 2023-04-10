using System.Reflection;
using Application.Behaivors;
using Application.Commands.OrderActions.CreateUpdateOrder;
using Application.Commands.OrderActions.DeleteOrder;
using Application.Commands.OrderItemActions.CreateUpdateItem;
using Application.Commands.OrderItemActions.DeleteItem;
using Application.Commands.Provider.CreateProvider;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DepInj;

public static class DepInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddValidators();
        services.AddBehaviors();
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(typeof(DepInjection).Assembly);
        });
        return services;
    }
    private static IServiceCollection AddValidators(
        this IServiceCollection services
    )
    {
        services.AddScoped<IValidator<CreateUpdateOrderCommand>,CreateUpdateOrderValidator>();
        services.AddScoped<IValidator<DeleteOrderCommand>,DeleteOrderValidator>();
        services.AddScoped<IValidator<CreateUpdateItemCommand>,CreateUpdateItemValidator>();
        services.AddScoped<IValidator<DeleteItemCommand>,DeleteItemValidator>();
        services.AddScoped<IValidator<CreateProviderCommand>,CreateProviderValidator>();
        return services;
    }
    private static IServiceCollection AddBehaviors(
        this IServiceCollection services
    )
    {
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}