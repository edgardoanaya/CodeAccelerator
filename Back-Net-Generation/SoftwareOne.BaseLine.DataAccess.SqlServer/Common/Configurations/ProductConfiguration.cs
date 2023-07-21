using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SoftwareOne.BaseLine.DataAccess.SqlServer.Common.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Entities.Product>
    {        
        public void Configure(EntityTypeBuilder<Entities.Product> builder)
        {
            if (builder != null) {
                builder.ToTable(nameof(Entities.Product));

                
                builder.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                 builder.Property(e => e.Name)
                    .IsRequired(true)
                    .IsUnicode(false);
                builder.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                 builder.Property(e => e.Price)
                    .IsRequired(true)
                    .IsUnicode(false);
                 builder.Property(e => e.UnitStock)
                    .IsRequired(true)
                    .IsUnicode(false);

            }
        }
    }
}
