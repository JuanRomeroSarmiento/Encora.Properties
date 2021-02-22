using Encora.Properties.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Encora.Properties.DataBase.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(ad => ad.PropertyId);

            builder.Property(ad => ad.AddressOne).HasMaxLength(256).IsRequired();
            builder.Property(ad => ad.AddressTwo).HasMaxLength(256).IsRequired(false);
            builder.Property(ad => ad.City).HasMaxLength(256).IsRequired();
            builder.Property(ad => ad.Country).HasMaxLength(256).IsRequired();
            builder.Property(ad => ad.County).HasMaxLength(256).IsRequired(false);
            builder.Property(ad => ad.District).HasMaxLength(256).IsRequired(false);
            builder.Property(ad => ad.State).HasMaxLength(256).IsRequired();
            builder.Property(ad => ad.Zip).HasMaxLength(5).IsRequired();
            builder.Property(ad => ad.ZipPlus4).HasMaxLength(10).IsRequired(false);
        }
    }
}
