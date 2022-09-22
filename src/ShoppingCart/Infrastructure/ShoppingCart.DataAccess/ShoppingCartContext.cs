using Microsoft.EntityFrameworkCore;
using ShoppingCart.DataAccess.EntityConfigurations.Product;
using ShoppingCart.DataAccess.EntityConfigurations.ShoppingCart;

namespace ShoppingCart.DataAccess;

public class ShoppingCartContext : DbContext
{
    /// <summary>
    /// Инициализирует экземпляр <see cref="ShoppingCartContext"/>.
    /// </summary>
    protected ShoppingCartContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ShoppingCartConfiguration());
    }
}