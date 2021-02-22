using Microsoft.EntityFrameworkCore;
using Encora.Properties.Entities;
using Encora.Properties.DataBase.Configurations;

namespace Encora.Properties.DataBase
{
    public class PropertyDBContext : DbContext
    {
        public PropertyDBContext(DbContextOptions<PropertyDBContext> options) : base(options)
        {
        }

        public DbSet<Property> Property { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("bnl");

            modelBuilder.ApplyConfiguration(new PropertyConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
        }
    }
}
