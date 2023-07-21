using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SoftwareOne.BaseLine.DataAccess.SqlServer.Common.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Entities.Customer>
    {        
        public void Configure(EntityTypeBuilder<Entities.Customer> builder)
        {
            if (builder != null) {
                builder.ToTable(nameof(Entities.Customer));

                
                builder.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                 builder.Property(e => e.Name)
                    .IsRequired(true)
                    .IsUnicode(false);
                builder.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                 builder.Property(e => e.Email)
                    .IsRequired(true)
                    .IsUnicode(false);
                 builder.Property(e => e.RegistrationDate)
                    .IsRequired(true)
                    .IsUnicode(false);

            }
        }
    }
}
