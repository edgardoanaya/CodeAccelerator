namespace SoftwareOne.BaseLine.Entities
{
    /// <summary>
    /// Entity to manage the Customer entity
    /// </summary>
    public partial class Customer : Core.Entities.BaseEntity, Core.Entities.IEntity
    {
        /// <summary>
        /// Property to manage the Name field
        /// </summary>
        
        public string Name { get; set; } = null!;
        /// <summary>
        /// Property to manage the Email field
        /// </summary>
        
        public string Email { get; set; } = null!;
        /// <summary>
        /// Property to manage the RegistrationDate field
        /// </summary>
        
        public DateTime RegistrationDate { get; set; } 
        /// <summary>
        /// Property to manage the IsVip field
        /// </summary>
        
        public bool IsVip { get; set; } = false!;
        /// <summary>
        /// Property to manage the ShoppingCartId field
        /// </summary>
        
        public int ShoppingCartId { get; set; } 
        /// <summary>
        /// Property to manage the ShoppingCart field
        /// </summary>
        
        public ShoppingCart ShoppingCart { get; set; } = null!;
        /// <summary>
        /// Property to manage the ShippingAddressId field
        /// </summary>
        [ForeignKey("ShippingAddress")]
        public int? ShippingAddressId { get; set; } 
        /// <summary>
        /// Property to manage the ShippingAddress field
        /// </summary>
        [JsonIgnore]
        public ShippingAddress? ShippingAddress { get; set; } = null!;

    }
}

