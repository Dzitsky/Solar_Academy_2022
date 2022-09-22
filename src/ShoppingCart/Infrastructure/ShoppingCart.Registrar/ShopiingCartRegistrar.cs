using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.DataAccess;
using ShoppingCart.DataAccess.Interfaces;

namespace ShoppingCart.Registrar;

public static class ShopiingCartRegistrar
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddDbContext<ShoppingCartContext>((Action<IServiceProvider, DbContextOptionsBuilder>)
            ((sp, dbOptions) => sp.GetRequiredService<IDbContextOptionsConfigurator<ShoppingCartContext>>()
                .Configure((DbContextOptionsBuilder<ShoppingCartContext>)dbOptions)));
        services.AddSingleton<IDbContextOptionsConfigurator<ShoppingCartContext>, ShoppingCartContextConfiguration>();
        services.AddScoped(sp => (DbContext)sp.GetRequiredService<ShoppingCartContext>());

        return services;
    }
}