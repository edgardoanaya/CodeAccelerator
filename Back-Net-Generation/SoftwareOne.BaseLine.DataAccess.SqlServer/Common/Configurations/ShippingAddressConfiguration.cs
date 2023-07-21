using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SoftwareOne.BaseLine.DataAccess.SqlServer.Common.Configurations
{
    public class ShippingAddressConfiguration : IEntityTypeConfiguration<Entities.ShippingAddress>
    {        
        public void Configure(EntityTypeBuilder<Entities.ShippingAddress> builder)
        {
            if (builder != null) {
                builder.ToTable(nameof(Entities.ShippingAddress));

                
                builder.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                 builder.Property(e => e.Name)
                    .IsRequired(true)
                    .IsUnicode(false);
                builder.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                 builder.Property(e => e.Address)
                    .IsRequired(true)
                    .IsUnicode(false);
                 builder.Property(e => e.CustomerId)
                    .IsRequired(true)
                    .IsUnicode(false);
                 builder.Property(e => e.CityId)
                    .IsRequired(true)
                    .IsUnicode(false);

            }
        }
    }
}
