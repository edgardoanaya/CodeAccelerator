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
// <summary>API Rest to expose the methods of the entity [Audit]</summary>
using Microsoft.AspNetCore.Authorization;

namespace SoftwareOne.BaseLine.Api.Controllers
{
    /// <summary>
    /// API RestFull to expose the methods of the entity [Audit]
    /// </summary>
    public partial class AuditController
    {
        /// <summary>
        /// Constructor to initialize the application services and the default context instance for the entity (Audit).
        /// </summary>
        public AuditController(
                                    Interfaces.ApplicationServices.Facade.IAudit IAudit,
                                    IAuthorizationService AuthorizationService
            ) : base(IAudit, AuthorizationService)
        {
            this.OrderDefaultEntity = nameof(Entities.Audit.Entity);
        }
    }
}