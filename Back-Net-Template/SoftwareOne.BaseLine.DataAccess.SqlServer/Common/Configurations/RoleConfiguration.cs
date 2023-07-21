using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SoftwareOne.BaseLine.DataAccess.SqlServer.Common.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Entities.Role>
    {
        /// <summary>
        /// Constant that contains max length for the name field.
        /// </summary>
        private const int NAME_MAX_LENGTH = 50;

        public void Configure(EntityTypeBuilder<Entities.Role> builder)
        {
            if (builder != null) {
                builder.ToTable(nameof(Entities.Role));
                builder.Property(e => e.Name)
                    .HasMaxLength(NAME_MAX_LENGTH)
                    .IsUnicode(false);
            }
        }
    }
}
