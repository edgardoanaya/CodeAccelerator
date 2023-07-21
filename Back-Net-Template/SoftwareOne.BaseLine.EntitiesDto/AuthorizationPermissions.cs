using SoftwareOne.BaseLine.Core.Entities;

namespace SoftwareOne.BaseLine.EntitiesDto
{
    public partial class AuthorizationPermissions : BaseEntityDto
    {
        public int EntityId { get; set; }
        public int RoleId { get; set; }
        public bool PermissionCreate { get; set; }
        public bool PermissionUpdate { get; set; }
        public bool PermissionDelete { get; set; }
        public bool PermissionView { get; set; }
        public bool PermissionList { get; set; }
        public string? EntityName { get; set; }
        public string? RoleName { get; set; }
    }
}