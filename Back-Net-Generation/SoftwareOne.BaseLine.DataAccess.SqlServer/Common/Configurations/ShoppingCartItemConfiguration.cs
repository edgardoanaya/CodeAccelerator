using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SoftwareOne.BaseLine.DataAccess.SqlServer.Common.Configurations
{
    public class ShoppingCartItemConfiguration : IEntityTypeConfiguration<Entities.ShoppingCartItem>
    {        
        public void Configure(EntityTypeBuilder<Entities.ShoppingCartItem> builder)
        {
            if (builder != null) {
                builder.ToTable(nameof(Entities.ShoppingCartItem));

                

            }
        }
    }
}
