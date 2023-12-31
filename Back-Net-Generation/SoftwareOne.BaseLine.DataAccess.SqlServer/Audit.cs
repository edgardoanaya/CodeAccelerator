//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// <copyright company="SoftwareOne">Copyright(c) 2023 All Rights Reserved.</copyright>
// <author>Jessica Antía Hortúa</author>
// <email>mailto:jessica.antia@softwareone.com</email>
// <summary>Class that represents the data access for the entity (Audit)</summary>
namespace SoftwareOne.BaseLine.DataAccess.SqlServer
{
    /// <summary>
    /// Class that represents the data access for the entity (Audit)
    /// </summary>
    public partial class Audit :
        Core.SqlServer.BaseRepositoryDataAccess<Entities.Audit>,
        Interfaces.DataAccess.IAudit
    {
        /// <summary>
        /// Constructor to initialize the context instace [MainContext] for the entity (Audit)
        /// </summary>
        /// <param name="context">Database context instace</param>
        public Audit(Core.DataAccess.IMainDataAccessContext context) : base(context) { } 
    }
}