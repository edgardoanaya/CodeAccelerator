using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SoftwareOne.BaseLine.DataAccess.SqlServer.Common.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Entities.User>
    {
        /// <summary>
        /// Constant that contains max length for the Name field.
        /// </summary>
        private const int NAME_MAX_LENGTH = 50;
        /// <summary>
        /// Constant that contains max length for the fields generic.
        /// </summary>
        private const int GENERIC_MAX_LENGTH = 100;
        /// <summary>
        /// Constant that contains max length for the PhoneNumber field.
        /// </summary>
        private const int PHONE_NUMBER_MAX_LENGTH = 20;
        
        public void Configure(EntityTypeBuilder<Entities.User> builder)
        {
            if(builder != null) {
                builder.ToTable(nameof(Entities.User));
                builder.Property(e => e.UserName)
                    .HasMaxLength(NAME_MAX_LENGTH)
                    .IsUnicode(false);
                builder.Property(e => e.FullName)
                    .HasMaxLength(NAME_MAX_LENGTH)
                    .IsUnicode(false);
                builder.Property(e => e.Email)
                    .HasMaxLength(GENERIC_MAX_LENGTH)
                    .IsUnicode(false);
                builder.Property(e => e.EmailConfirmed)
                    .IsUnicode(false);
                builder.Property(e => e.PasswordHash)
                    .HasMaxLength(GENERIC_MAX_LENGTH)
                    .IsUnicode(false);
                builder.Property(e => e.PhoneNumber)
                    .IsRequired(false)
                    .HasMaxLength(PHONE_NUMBER_MAX_LENGTH)
                    .IsUnicode(false);
                builder.Property(e => e.State)
                    .IsUnicode(false);
                builder.Property(e => e.RoleId)
                    .IsUnicode(false);
                builder.Property(e => e.Salt)
                    .HasMaxLength(GENERIC_MAX_LENGTH)
                    .IsUnicode(false);
            }
        }
    }
}
