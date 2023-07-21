namespace SoftwareOne.BaseLine.Entities
{
    /// <summary>
    /// Entity to manage the Product entity
    /// </summary>
    public partial class Product : Core.Entities.BaseEntity, Core.Entities.IEntity
    {
        /// <summary>
        /// Property to manage the Name field
        /// </summary>
        
        public string Name { get; set; } = null!;
        /// <summary>
        /// Property to manage the Description field
        /// </summary>
        
        public string Description { get; set; } = null!;
        /// <summary>
        /// Property to manage the Price field
        /// </summary>
        
        public decimal Price { get; set; } = 0!;
        /// <summary>
        /// Property to manage the UnitStock field
        /// </summary>
        
        public int UnitStock { get; set; } = 0!;
        /// <summary>
        /// Property to manage the Categories field
        /// </summary>
        
        public List<Category> Categories { get; set; } = null!;

    }
}

