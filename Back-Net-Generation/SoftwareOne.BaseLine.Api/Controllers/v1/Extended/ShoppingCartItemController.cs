// <copyright company="SoftwareOne">Copyright(c) 2023 All Rights Reserved.</copyright>
// <author>Santiago Gil Roldán</author>
// <email>mailto:santiago.gil2@softwareone.com</email>
// <summary>API RestFull to expose the methods of the entity [ShoppingCartItem]</summary>
using Microsoft.AspNetCore.Authorization;

namespace SoftwareOne.BaseLine.Api.Controllers
{
    /// <summary>
    /// API RestFull to expose the methods of the entity [ShoppingCartItem]
    /// </summary>
    public partial class ShoppingCartItemController
    {
        /// <summary>
        /// Constructor to initialize the application services and the default context instance for the entity (ShoppingCartItem).
        /// </summary>
        public ShoppingCartItemController(
                                    Interfaces.ApplicationServices.Facade.IShoppingCartItem facadeShoppingCartItem,
                                    IAuthorizationService AuthorizationService
            ) : base(facadeShoppingCartItem, AuthorizationService)
        {
            this.OrderDefaultEntity = nameof(Entities.ShoppingCartItem.Price);
        }
    }
}