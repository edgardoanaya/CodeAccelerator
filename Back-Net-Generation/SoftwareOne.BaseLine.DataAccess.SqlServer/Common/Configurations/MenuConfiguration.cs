using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SoftwareOne.BaseLine.DataAccess.SqlServer.Common.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Entities.Menu>
    {
        /// <summary>
        /// Constant that contains max length for the fields generic.
        /// </summary>
        private const int GENERIC_MAX_LENGTH = 500;
        public void Configure(EntityTypeBuilder<Entities.Menu> builder)
        {
            if(builder != null) {
                builder.ToTable(nameof(Entities.Menu));
                
                builder.Property(e => e.Path)
                    .HasMaxLength(GENERIC_MAX_LENGTH)
                    .IsUnicode(false);
                builder.Property(e => e.Title)
                    .HasMaxLength(GENERIC_MAX_LENGTH)
                    .IsUnicode(false);
                builder.Property(e => e.Icon)
                    .HasMaxLength(GENERIC_MAX_LENGTH)
                    .IsUnicode(false);
                builder.Property(e => e.Class)
                    .HasMaxLength(GENERIC_MAX_LENGTH)
                    .IsUnicode(false);
                builder.Property(e => e.Badge)
                    .HasMaxLength(GENERIC_MAX_LENGTH)
                    .IsUnicode(false);
                builder.Property(e => e.BadgeClass)
                    .HasMaxLength(GENERIC_MAX_LENGTH)
                    .IsUnicode(false);
            }
        }
    }
}
