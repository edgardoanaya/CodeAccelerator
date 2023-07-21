using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SoftwareOne.BaseLine.DataAccess.SqlServer.Common.Configurations
{
    public class AuditConfiguration : IEntityTypeConfiguration<Entities.Audit>
    {
        /// <summary>
        /// Constant that contains max length for the Name field.
        /// </summary>
        private const int NAME_MAX_LENGTH = 50;
        public void Configure(EntityTypeBuilder<Entities.Audit> builder)
        {
            if (builder != null) {
                builder.ToTable(nameof(Entities.Audit));
                
                //builder.Property(e => e.Name)
                //    .HasMaxLength(NAME_MAX_LENGTH)
                //    .IsUnicode(false);
            }
        }
    }
}
