// <copyright company="SoftwareOne">Copyright(c) 2023 All Rights Reserved.</copyright>
// <author>Santiago Gil Roldán</author>
// <email>mailto:santiago.gil2@softwareone.com</email>
// <summary>API RestFull to expose the methods of the entity [Menu]</summary>
using Microsoft.AspNetCore.Authorization;

namespace SoftwareOne.BaseLine.Api.Controllers
{
    /// <summary>
    /// API RestFull to expose the methods of the entity [Menu]
    /// </summary>
    public partial class MenuController
    {
        /// <summary>
        /// Constructor to initialize the application services and the default context instance for the entity (Menu).
        /// </summary>
        public MenuController(
                                    Interfaces.ApplicationServices.Facade.IMenu facadeMenu,
                                    IAuthorizationService AuthorizationService
            ) : base(facadeMenu, AuthorizationService)
        {
            this.OrderDefaultEntity = nameof(Entities.Menu.Title);
        }
    }
}