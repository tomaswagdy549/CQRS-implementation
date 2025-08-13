using App.Infrastructure;
using Catalog.Application.Common.Interfaces;
using Catalog.Core.Interfaces.GenericRepositoryInterface;
using Catalog.Core.Interfaces.IFileManager;
using Catalog.Core.Interfaces.IUnitOfWork;
using Catalog.Core.Repositories.IBrand;
using Catalog.Core.Repositories.IProduct;
using Catalog.Core.Repositories.IProductType;
using Catalog.Infrastructure.Data.Contexts;
using Catalog.Infrastructure.FileManager;
using Catalog.Infrastructure.Repositories.Brand;
using Catalog.Infrastructure.Repositories.GenericRepository.Add;
using Catalog.Infrastructure.Repositories.Products;
using Catalog.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infrastructure;
public static class InfrastructureDependancyInjection
{
    public static IServiceCollection AddCatalogInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer("Server=.;Database=YourDatabaseName;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=True");
        });

        services.AddScoped<ICatalogContext, CatalogContext>();
        services.AddHttpContextAccessor();
        services.AddScoped<IAuditService, AuditService>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped(typeof(IAdd<>), typeof(Add<>));
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        services.AddScoped<IFileManager, FileManager.FileManager>();
        return services;
    }
}