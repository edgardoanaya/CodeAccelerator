using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SoftwareOne.BaseLine.DataAccess.SqlServer.Common.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Entities.Category>
    {        
        public void Configure(EntityTypeBuilder<Entities.Category> builder)
        {
            if (builder != null) {
                builder.ToTable(nameof(Entities.Category));

                
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
