namespace SoftwareOne.BaseLine.Entities
{
    /// <summary>
    /// Entity to manage the ShoppingCartItem entity
    /// </summary>
    public partial class ShoppingCartItem : Core.Entities.BaseEntity, Core.Entities.IEntity
    {
        /// <summary>
        /// Property to manage the ProductId field
        /// </summary>
        [ForeignKey("Product")]
        public int ProductId { get; set; } 
        /// <summary>
        /// Property to manage the Product field
        /// </summary>
        [JsonIgnore]
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
        [ForeignKey("ShoppingCart")]
        public int ShoppingCartId { get; set; } 
        /// <summary>
        /// Property to manage the ShoppingCart field
        /// </summary>
        [JsonIgnore]
        public ShoppingCart ShoppingCart { get; set; } = null!;

    }
}

