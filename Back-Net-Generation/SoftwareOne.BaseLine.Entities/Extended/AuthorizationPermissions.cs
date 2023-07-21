namespace SoftwareOne.BaseLine.Entities
{
    public partial class AuthorizationPermissions : Core.Entities.BaseEntity, Core.Entities.IEntity
    {
        public string? EntityName => this.Entity?.Name;
        public string? RoleName => this.Role?.Name;
    }
}