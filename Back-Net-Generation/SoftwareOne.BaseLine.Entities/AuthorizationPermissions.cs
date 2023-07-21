using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SoftwareOne.BaseLine.Entities
{
    public partial class AuthorizationPermissions : Core.Entities.BaseEntity, Core.Entities.IEntity
    {
        [ForeignKey("Entity")]
        public int EntityId { get; set; }
        [JsonIgnore]
        public Entity Entity { get; set; } = null!;
        
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        [JsonIgnore]
        public Role Role { get; set; } = null!;
        public bool PermissionCreate { get; set; }
        public bool PermissionUpdate { get; set; }
        public bool PermissionDelete { get; set; }
        public bool PermissionView { get; set; }
        public bool PermissionList { get; set; }
    }
}