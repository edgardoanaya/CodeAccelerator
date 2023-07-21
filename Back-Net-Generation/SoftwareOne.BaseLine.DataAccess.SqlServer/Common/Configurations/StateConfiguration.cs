using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SoftwareOne.BaseLine.DataAccess.SqlServer.Common.Configurations
{
    public class StateConfiguration : IEntityTypeConfiguration<Entities.State>
    {        
        public void Configure(EntityTypeBuilder<Entities.State> builder)
        {
            if (builder != null) {
                builder.ToTable(nameof(Entities.State));

                
                builder.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

            }
        }
    }
}
