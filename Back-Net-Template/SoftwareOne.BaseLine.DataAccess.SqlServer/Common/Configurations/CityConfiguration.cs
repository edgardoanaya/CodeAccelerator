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

                //{MaxLengthField}

            }
        }
    }
}
