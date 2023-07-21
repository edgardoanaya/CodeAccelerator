using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SoftwareOne.BaseLine.DataAccess.SqlServer.Common.Configurations
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<Entities.ShoppingCart>
    {        
        public void Configure(EntityTypeBuilder<Entities.ShoppingCart> builder)
        {
            if (builder != null) {
                builder.ToTable(nameof(Entities.ShoppingCart));

                
                 builder.Property(e => e.CustomerId)
                    .IsRequired(true)
                    .IsUnicode(false);
                 builder.Property(e => e.TotalPrice)
                    .IsRequired(true)
                    .IsUnicode(false);

            }
        }
    }
}
