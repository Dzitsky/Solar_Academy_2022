using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ShoppingCart.Domain;

namespace ShoppingCart.DataAccess;

/// <summary>
/// Контекст БД
/// </summary>
public class ShoppingCartContext : IdentityDbContext<ApplicationUser>
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

        base.OnModelCreating(modelBuilder);
    }
}