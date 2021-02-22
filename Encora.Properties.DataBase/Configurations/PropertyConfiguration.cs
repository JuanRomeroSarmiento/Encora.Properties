using Encora.Properties.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Encora.Properties.DataBase.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedNever();
            builder.Property(p => p.YearBuilt).HasMaxLength(4).IsRequired(false);

            builder.HasOne(p => p.Address).WithOne(a => a.Property).HasForeignKey<Address>(a => a.PropertyId);
        }
    }
}
