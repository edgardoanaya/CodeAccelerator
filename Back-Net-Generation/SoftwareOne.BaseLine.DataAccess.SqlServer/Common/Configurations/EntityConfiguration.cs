using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SoftwareOne.BaseLine.DataAccess.SqlServer.Common.Configurations
{
    public class EntityConfiguration : IEntityTypeConfiguration<Entities.Entity>
    {
        /// <summary>
        /// Constant that contains max length for the Name field.
        /// </summary>
        private const int NAME_MAX_LENGTH = 50;
        public void Configure(EntityTypeBuilder<Entities.Entity> builder)
        {
            if(builder != null) {
                builder.ToTable(nameof(Entities.Entity));

                builder.Property(e => e.Name)
                    .HasMaxLength(NAME_MAX_LENGTH)
                    .IsUnicode(false);
            }
        }
    }
}
