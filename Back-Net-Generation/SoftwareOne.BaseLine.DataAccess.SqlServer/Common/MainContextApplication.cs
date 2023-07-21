using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace SoftwareOne.BaseLine.DataAccess.SqlServer.Common
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainContextApplication : DbContext, Core.DataAccess.IMainDataAccessContext
    {
        /// <summary>
        /// 
        /// </summary>
        public MainContextApplication() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public MainContextApplication(DbContextOptions<MainContextApplication> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}