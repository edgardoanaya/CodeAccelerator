using SoftwareOne.BaseLine.Core.Entities;

namespace SoftwareOne.BaseLine.EntitiesDto
{
    /// <summary>
    /// Entity to manage the Category entity
    /// </summary>
    public partial class Category : BaseEntityDto
    {        
        /// <summary>
        /// Property to manage the Name field
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Property to manage the InscriptionDate field
        /// </summary>
        public DateTime? InscriptionDate { get; set; } 
        /// <summary>
        /// Property to manage the AppliesDiscount field
        /// </summary>
        public bool AppliesDiscount { get; set; } 
        /// <summary>
        /// Property to manage the Products field
        /// </summary>
        public List<Product> Products { get; set; } = null!;
    }
}