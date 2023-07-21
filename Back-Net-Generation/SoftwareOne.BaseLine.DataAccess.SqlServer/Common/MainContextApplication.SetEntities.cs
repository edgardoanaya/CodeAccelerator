using Microsoft.EntityFrameworkCore;

namespace SoftwareOne.BaseLine.DataAccess.SqlServer.Common
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainContextApplication
    {        
        public virtual DbSet<Entities.Menu>? Menu { get; set; }
        public virtual DbSet<Entities.AuthorizationPermissions>? AuthorizationPermissions { get; set; }
        public virtual DbSet<Entities.User>? Users { get; set; }        
        public virtual DbSet<Entities.Category>? Category { get; set; }
        public virtual DbSet<Entities.City>? City { get; set; }
        public virtual DbSet<Entities.Customer>? Customer { get; set; }
        public virtual DbSet<Entities.Product>? Product { get; set; }
        public virtual DbSet<Entities.ShippingAddress>? ShippingAddress { get; set; }
        public virtual DbSet<Entities.ShoppingCart>? ShoppingCart { get; set; }
        public virtual DbSet<Entities.ShoppingCartItem>? ShoppingCartItem { get; set; }
        public virtual DbSet<Entities.State>? State { get; set; }
        
        
    }
}