namespace SoftwareOne.BaseLine.Entities
{
    /// <summary>
    /// Entity to manage the Audit entity
    /// </summary>
    public partial class Audit : Core.Entities.IEntity
    {
        /// <summary>
        /// Property to manage the Id field
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Property to manage the Entity field
        /// </summary>
        public string Entity { get; set; } = null!;
        /// <summary>
        /// Property to manage the Operation field
        /// </summary>
        public string Operation { get; set; } = null!;
        /// <summary>
        /// Property to manage the NewRecord field
        /// </summary>
        public string NewRecord { get; set; } = null!;
        /// <summary>
        /// Property to manage the OldRecord field
        /// </summary>
        public string? OldRecord { get; set; } = null!;
        /// <summary>
        /// Property to manage the UrlSource field
        /// </summary>
        public string UrlSource { get; set; } = null!;
        /// <summary>
        /// Property to manage the Username field
        /// </summary>
        public string Username { get; set; } = null!;
         /// <summary>
        /// Property to manage the IpAddress field
        /// </summary>
        public string IpAddress { get; set; } = null!;
         /// <summary>
        /// Property to manage the Application field
        /// </summary>
        public string? Application { get; set; }
        /// <summary>
        /// Property to manage the AuditDate field
        /// </summary>
        public DateTime AuditDate { get; set; }
    }
}