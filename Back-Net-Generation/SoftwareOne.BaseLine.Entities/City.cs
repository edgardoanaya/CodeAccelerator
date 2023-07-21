namespace SoftwareOne.BaseLine.Entities
{
    /// <summary>
    /// Entity to manage the City entity
    /// </summary>
    public partial class City : Core.Entities.BaseEntity, Core.Entities.IEntity
    {
        /// <summary>
        /// Property to manage the StateLocationId field
        /// </summary>
        [ForeignKey("StateLocation")]
        public int StateLocationId { get; set; } 
        /// <summary>
        /// Property to manage the StateLocation field
        /// </summary>
        [JsonIgnore]
        public State StateLocation { get; set; } 
        /// <summary>
        /// Property to manage the Name field
        /// </summary>
        
        public string Name { get; set; } = null!;

    }
}

