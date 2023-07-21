// <copyright company="SoftwareOne">Copyright(c) 2023 All Rights Reserved.</copyright>
// <author>Santiago Gil Roldán</author>
// <email>mailto:santiago.gil2@softwareone.com</email>
// <summary>API RestFull to expose the methods of the entity [Audit]</summary>
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
                                    Interfaces.ApplicationServices.Facade.IAudit facadeAudit,
                                    IAuthorizationService AuthorizationService
            ) : base(facadeAudit, AuthorizationService)
        {
            //this.OrderDefaultEntity = nameof(Entities.Audit.Name);
        }
    }
}