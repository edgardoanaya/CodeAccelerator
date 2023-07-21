using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SoftwareOne.BaseLine.DataAccess.SqlServer.Common.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<Entities.City>
    {        
        public void Configure(EntityTypeBuilder<Entities.City> builder)
        {
            if (builder != null) {
                builder.ToTable(nameof(Entities.City));

                
                 builder.Property(e => e.StateLocationId)
                    .IsRequired(true)
                    .IsUnicode(false);
                builder.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                 builder.Property(e => e.Name)
                    .IsRequired(true)
                    .IsUnicode(false);

            }
        }
    }
}
