namespace SoftwareOne.BaseLine.Entities
{
    /// <summary>
    /// Entity to manage the ShoppingCart entity
    /// </summary>
    public partial class ShoppingCart : Core.Entities.BaseEntity, Core.Entities.IEntity
    {
        /// <summary>
        /// Property to manage the CustomerId field
        /// </summary>
        [ForeignKey("Customer")]
        public int CustomerId { get; set; } 
        /// <summary>
        /// Property to manage the Customer field
        /// </summary>
        [JsonIgnore]
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

