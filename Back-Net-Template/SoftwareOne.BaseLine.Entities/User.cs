using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SoftwareOne.BaseLine.Entities
{
    /// <summary>
    /// Entity to manage the User entity
    /// </summary>
    public partial class User : Core.Entities.BaseEntity, Core.Entities.IEntity
    {
        public string UserName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool EmailConfirmed { get; set; } = false!;
        public string PasswordHash { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        /// <summary>
        /// Property to manage the RoleId field
        /// </summary>
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        /// <summary>
        /// Property to manage the Role field
        /// </summary>
        [JsonIgnore]
        public Role Role { get; set; } = null!;
        public string Salt { get; set; } = null!;
    }
}