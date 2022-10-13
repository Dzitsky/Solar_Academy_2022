using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoppingCart.DataAccess.EntityConfigurations.Product;

/// <summary>
/// Конфигурация таблицы Products.
/// </summary>
public class UserConfiguration : IEntityTypeConfiguration<Domain.User>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Domain.User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedOnAdd();

        builder.Property(b => b.Name).HasMaxLength(100);

        builder.Property(b => b.Login).HasMaxLength(20);
        
        builder.Property(b => b.Password).HasMaxLength(100);
    }
}