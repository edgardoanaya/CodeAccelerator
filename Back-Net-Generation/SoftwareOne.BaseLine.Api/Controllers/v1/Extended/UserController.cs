// <copyright company="SoftwareOne">Copyright(c) 2023 All Rights Reserved.</copyright>
// <author>Santiago Gil Roldán</author>
// <email>mailto:santiago.gil2@softwareone.com</email>
// <summary>API RestFull to expose the methods of the entity [User]</summary>
using Microsoft.AspNetCore.Authorization;

namespace SoftwareOne.BaseLine.Api.Controllers
{
    /// <summary>
    /// API RestFull to expose the methods of the entity [User]
    /// </summary>
    public partial class UserController
    {
        /// <summary>
        /// Constructor to initialize the application services and the default context instance for the entity (User).
        /// </summary>
        public UserController(
                                    Interfaces.ApplicationServices.Facade.IUser facadeUser,
                                    IAuthorizationService AuthorizationService
            ) : base(facadeUser, AuthorizationService)
        {
            this.OrderDefaultEntity = nameof(Entities.User.UserName);
        }
    }
}