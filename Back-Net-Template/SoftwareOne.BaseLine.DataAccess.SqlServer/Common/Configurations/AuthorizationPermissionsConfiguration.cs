using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SoftwareOne.BaseLine.DataAccess.SqlServer.Common.Configurations
{
    public class AuthorizationPermissionsConfiguration : IEntityTypeConfiguration<Entities.AuthorizationPermissions>
    {
        public void Configure(EntityTypeBuilder<Entities.AuthorizationPermissions> builder)
        {
            if (builder != null) {
                builder.ToTable(nameof(Entities.AuthorizationPermissions));
            }
        }
    }
}
