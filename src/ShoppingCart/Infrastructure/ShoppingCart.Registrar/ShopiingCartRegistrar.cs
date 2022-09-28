using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.AppServices.Product.Repositories;
using ShoppingCart.AppServices.Product.Services;
using ShoppingCart.AppServices.Services;
using ShoppingCart.DataAccess;
using ShoppingCart.DataAccess.EntityConfigurations.Product;
using ShoppingCart.DataAccess.Interfaces;
using ShoppingCart.Infrastructure.Repository;

namespace ShoppingCart.Registrar;

public static class ShopiingCartRegistrar
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeService, DateTimeService>();
        services.AddSingleton<IDbContextOptionsConfigurator<ShoppingCartContext>, ShoppingCartContextConfiguration>();
        
        services.AddDbContext<ShoppingCartContext>((Action<IServiceProvider, DbContextOptionsBuilder>)
            ((sp, dbOptions) => sp.GetRequiredService<IDbContextOptionsConfigurator<ShoppingCartContext>>()
                .Configure((DbContextOptionsBuilder<ShoppingCartContext>)dbOptions)));

        services.AddScoped((Func<IServiceProvider, DbContext>) (sp => sp.GetRequiredService<ShoppingCartContext>()));
        
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        
        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<IProductRepository, ProductRepository>();

        return services;
    }
}