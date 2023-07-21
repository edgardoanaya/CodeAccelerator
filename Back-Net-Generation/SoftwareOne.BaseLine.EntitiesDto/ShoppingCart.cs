using SoftwareOne.BaseLine.Core.Entities;

namespace SoftwareOne.BaseLine.EntitiesDto
{
    /// <summary>
    /// Entity to manage the ShoppingCart entity
    /// </summary>
    public partial class ShoppingCart : BaseEntityDto
    {        
        /// <summary>
        /// Property to manage the CustomerId field
        /// </summary>
        public int CustomerId { get; set; } 
        /// <summary>
        /// Property to manage the Customer field
        /// </summary>
        public Customer Customer { get; set; } = null!;
        /// <summary>
        /// Property to manage the TotalPrice field
        /// </summary>
        public decimal TotalPrice { get; set; } = 0!;
        /// <summary>
        /// Property to manage the Items field
        /// </summary>
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
    }
}