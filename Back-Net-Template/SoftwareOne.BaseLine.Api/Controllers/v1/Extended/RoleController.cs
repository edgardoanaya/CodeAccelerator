// <copyright company="SoftwareOne">Copyright(c) 2023 All Rights Reserved.</copyright>
// <author>Santiago Gil Roldán</author>
// <email>mailto:santiago.gil2@softwareone.com</email>
// <summary>API RestFull to expose the methods of the entity [Role]</summary>
using Microsoft.AspNetCore.Authorization;

namespace SoftwareOne.BaseLine.Api.Controllers
{
    /// <summary>
    /// API RestFull to expose the methods of the entity [Role]
    /// </summary>
    public partial class RoleController
    {
        /// <summary>
        /// Constructor to initialize the application services and the default context instance for the entity (Role).
        /// </summary>
        public RoleController(
                                    Interfaces.ApplicationServices.Facade.IRole facadeRole,
                                    IAuthorizationService AuthorizationService
            ) : base(facadeRole, AuthorizationService)
        {
            this.OrderDefaultEntity = nameof(Entities.Role.Name);
        }
    }
}