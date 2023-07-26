using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SoftwareOne.BaseLine.Entities
{
    /// <summary>
    /// Entity to manage the ShippingAddress entity
    /// </summary>
    public partial class ShippingAddress : Core.Entities.BaseEntity, Core.Entities.IEntity
    {
        /// <summary>
        /// Property to manage the Name field
        /// </summary>
        
        public string Name { get; set; } = null!;
        /// <summary>
        /// Property to manage the Address field
        /// </summary>
        
        public string Address { get; set; } = null!;
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
        /// Property to manage the CityId field
        /// </summary>
        [ForeignKey("City")]
        public int CityId { get; set; } 
        /// <summary>
        /// Property to manage the City field
        /// </summary>
        [JsonIgnore]
        public City City { get; set; } = null!;

    }
}

