using SoftwareOne.BaseLine.Core.Entities;

namespace SoftwareOne.BaseLine.EntitiesDto
{
    /// <summary>
    /// Entity to manage the ShippingAddress entity
    /// </summary>
    public partial class ShippingAddress : BaseEntityDto
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
        public int CustomerId { get; set; } 
        /// <summary>
        /// Property to manage the Customer field
        /// </summary>
        public Customer Customer { get; set; } = null!;
        /// <summary>
        /// Property to manage the CityId field
        /// </summary>
        public int CityId { get; set; } 
        /// <summary>
        /// Property to manage the City field
        /// </summary>
        public City City { get; set; } = null!;
    }
}