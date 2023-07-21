using SoftwareOne.BaseLine.Core.Entities;

namespace SoftwareOne.BaseLine.EntitiesDto
{
    /// <summary>
    /// Entity to manage the User entity
    /// </summary>
    public partial class User : BaseEntityDto
    {
        public string UserName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool EmailConfirmed { get; set; } = false!;
        public string PasswordHash { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int RoleId { get; set; }
        /// <summary>
        /// Property to manage the RoleName field
        /// </summary>
        public string? RoleName { get; set; } = null!;
    }
}