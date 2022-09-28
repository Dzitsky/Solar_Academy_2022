using Microsoft.EntityFrameworkCore;
using ShoppingCart.DataAccess.EntityConfigurations.Product;
using ShoppingCart.DataAccess.EntityConfigurations.ShoppingCart;

namespace ShoppingCart.DataAccess;

/// <summary>
/// Контекст БД
/// </summary>
public class ShoppingCartContext : DbContext
{
    /// <summary>
    /// Инициализирует экземпляр <see cref="ShoppingCartContext"/>.
    /// </summary>
    public ShoppingCartContext(DbContextOptions options)
        : base(options)
    {
    }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ShoppingCartConfiguration());
    }
}