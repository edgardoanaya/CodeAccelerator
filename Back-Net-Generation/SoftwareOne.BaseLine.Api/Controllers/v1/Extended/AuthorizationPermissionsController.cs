// <copyright company="SoftwareOne">Copyright(c) 2023 All Rights Reserved.</copyright>
// <author>Santiago Gil Roldán</author>
// <email>mailto:santiago.gil2@softwareone.com</email>
// <summary>API RestFull to expose the methods of the entity [AuthorizationPermissions]</summary>
using Microsoft.AspNetCore.Authorization;

namespace SoftwareOne.BaseLine.Api.Controllers
{
    /// <summary>
    /// API RestFull to expose the methods of the entity [AuthorizationPermissions]
    /// </summary>
    public partial class AuthorizationPermissionsController
    {
        /// <summary>
        /// Constructor to initialize the application services and the default context instance for the entity (AuthorizationPermissions).
        /// </summary>
        public AuthorizationPermissionsController(
                                    Interfaces.ApplicationServices.Facade.IAuthorizationPermissions facadeAuthorizationPermissions,
                                    IAuthorizationService AuthorizationService
            ) : base(facadeAuthorizationPermissions, AuthorizationService)
        {
            this.OrderDefaultEntity = nameof(Entities.AuthorizationPermissions.EntityId);
        }
    }
}