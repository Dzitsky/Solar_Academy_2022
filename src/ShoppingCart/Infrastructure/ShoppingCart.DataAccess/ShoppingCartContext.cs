using System.Reflection;
using Microsoft.EntityFrameworkCore;

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
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), t => t.GetInterfaces().Any(i =>
                i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));
    }
}