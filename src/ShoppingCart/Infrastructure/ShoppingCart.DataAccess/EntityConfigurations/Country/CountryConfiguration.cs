using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoppingCart.DataAccess.EntityConfigurations.Country
{
    public class CountryConfiguration : IEntityTypeConfiguration<Domain.Country>
    {
        public void Configure(EntityTypeBuilder<Domain.Country> builder)
        {
            builder.ToTable("Countries");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name);
            builder.Property(x => x.Code);

            builder.HasMany(x => x.Products)
                .WithOne(x => x.ProducingCountry)
                .HasForeignKey(x => x.ProducingCountryId);
        }
    }
}