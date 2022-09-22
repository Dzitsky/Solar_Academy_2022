using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoppingCart.DataAccess.EntityConfigurations.Product;

public class ProductConfiguration : IEntityTypeConfiguration<Domain.Product>
{
    public void Configure(EntityTypeBuilder<Domain.Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedOnAdd();

        builder.Property(b => b.Name).HasMaxLength(800);

        builder.HasMany(p => p.ShoppingCarts)
            .WithOne(s => s.Product)
            .HasForeignKey(s => s.ProductId);
    }
}