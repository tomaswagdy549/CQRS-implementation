using Microsoft.Extensions.DependencyInjection;
namespace Catalog.Presentation
{
    public static class PresentationDependancyInjection
    {
        public static IServiceCollection AddCatalogPresentation(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
            });
            services.AddControllers()
            .AddApplicationPart(typeof(Catalog.Presentation.PresentationDependancyInjection).Assembly);
            return services;
        }
    }
}
