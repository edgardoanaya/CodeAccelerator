// <copyright company="SoftwareOne">Copyright(c) 2023 All Rights Reserved.</copyright>
// <author>Santiago Gil Roldán</author>
// <email>mailto:santiago.gil2@softwareone.com</email>
// <summary>API RestFull to expose the methods of the entity [ShoppingCart]</summary>
using Microsoft.AspNetCore.Authorization;

namespace SoftwareOne.BaseLine.Api.Controllers
{
    /// <summary>
    /// API RestFull to expose the methods of the entity [ShoppingCart]
    /// </summary>
    public partial class ShoppingCartController
    {
        /// <summary>
        /// Constructor to initialize the application services and the default context instance for the entity (ShoppingCart).
        /// </summary>
        public ShoppingCartController(
                                    Interfaces.ApplicationServices.Facade.IShoppingCart facadeShoppingCart,
                                    IAuthorizationService AuthorizationService
            ) : base(facadeShoppingCart, AuthorizationService)
        {
            this.OrderDefaultEntity = nameof(Entities.ShoppingCart.CustomerId);
        }
    }
}