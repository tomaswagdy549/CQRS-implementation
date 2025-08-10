using Catalog.Application.Behaviours.TimePerformancePipeLineBehaviour;
using Catalog.Application.Behaviours.UnitOfWorkPipeLineBehaviour;
using Catalog.Application.Behaviours.ValidationPipeLineBehaviour;
using Catalog.Core.Entities;
using Catalog.Application.Features.Products.MappingProfile;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Application;
public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddCatalogServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ProductMappingProfile).Assembly);
        services.AddValidatorsFromAssemblyContaining(typeof(ApplicationDependencyInjection));
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(typeof(ProductMappingProfile).Assembly);
            cfg.AddOpenBehavior(typeof(TimePerformancePipeLineBehaviour<,>), serviceLifetime: ServiceLifetime.Scoped);
            cfg.AddOpenBehavior(typeof(ValidationPipeLineBehaviour<,>), serviceLifetime: ServiceLifetime.Scoped);
            cfg.AddOpenBehavior(typeof(UnitOfWorkPipeLineBehaviour<,>), serviceLifetime: ServiceLifetime.Scoped);
        }
        );

        return services;
    }
}