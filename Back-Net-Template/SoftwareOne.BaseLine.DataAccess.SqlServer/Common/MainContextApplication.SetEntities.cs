using Microsoft.EntityFrameworkCore;

namespace SoftwareOne.BaseLine.DataAccess.SqlServer.Common
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainContextApplication
    {
        public virtual DbSet<Entities.City>? Cities { get; set; }
        public virtual DbSet<Entities.Menu>? Menu { get; set; }
        public virtual DbSet<Entities.AuthorizationPermissions>? AuthorizationPermissions { get; set; }
        public virtual DbSet<Entities.User>? Users { get; set; }
        
        //{DbSet.Entities.City}

    }
}