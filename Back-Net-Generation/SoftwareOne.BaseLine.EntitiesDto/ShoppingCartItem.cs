using SoftwareOne.BaseLine.Core.Entities;

namespace SoftwareOne.BaseLine.EntitiesDto
{
    /// <summary>
    /// Entity to manage the ShoppingCartItem entity
    /// </summary>
    public partial class ShoppingCartItem : BaseEntityDto
    {        
        /// <summary>
        /// Property to manage the ProductId field
        /// </summary>
        public int ProductId { get; set; } 
        /// <summary>
        /// Property to manage the Product field
        /// </summary>
        public Product Product { get; set; } = null!;
        /// <summary>
        /// Property to manage the Quantity field
        /// </summary>
        public int Quantity { get; set; } = 0!;
        /// <summary>
        /// Property to manage the Price field
        /// </summary>
        public decimal Price { get; set; } = 0!;
        /// <summary>
        /// Property to manage the Discount field
        /// </summary>
        public decimal Discount { get; set; } = 0!;
        /// <summary>
        /// Property to manage the ShoppingCartId field
        /// </summary>
        public int ShoppingCartId { get; set; } 
        /// <summary>
        /// Property to manage the ShoppingCart field
        /// </summary>
        public ShoppingCart ShoppingCart { get; set; } = null!;
    }
}