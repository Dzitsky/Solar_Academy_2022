using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ShoppingCart.AppServices;
using ShoppingCart.AppServices.Product.Repositories;
using ShoppingCart.AppServices.Product.Services;
using ShoppingCart.AppServices.Services;
using ShoppingCart.AppServices.ShoppingCart.Repositories;
using ShoppingCart.AppServices.ShoppingCart.Services;
using ShoppingCart.DataAccess;
using ShoppingCart.DataAccess.EntityConfigurations.Product;
using ShoppingCart.DataAccess.EntityConfigurations.ShoppingCart;
using ShoppingCart.DataAccess.Interfaces;
using ShoppingCart.Infrastructure.Identity;
using ShoppingCart.Infrastructure.Repository;

namespace ShoppingCart.Registrar;

public static class ShopingCartRegistrar
{
    public static IServiceCollection AddServiceRegistrationModule(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeService, DateTimeService>();
        services.AddSingleton<IDbContextOptionsConfigurator<ShoppingCartContext>, ShoppingCartContextConfiguration>();

        services.AddDbContext<ShoppingCartContext>((Action<IServiceProvider, DbContextOptionsBuilder>)
            ((sp, dbOptions) => sp.GetRequiredService<IDbContextOptionsConfigurator<ShoppingCartContext>>()
                .Configure((DbContextOptionsBuilder<ShoppingCartContext>)dbOptions)));

        services.AddScoped((Func<IServiceProvider, DbContext>)(sp => sp.GetRequiredService<ShoppingCartContext>()));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IUserRepository, UserRepository>();

        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<IProductRepository, ProductRepository>();

        services.AddTransient<IShoppingCartService, ShoppingCartService>();
        services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();

        services.AddScoped<IClaimsAccessor, HttpContextClaimsAccessor>();

        return services;
    }
}