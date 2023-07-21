// <copyright company="SoftwareOne">Copyright(c) 2023 All Rights Reserved.</copyright>
// <author>Santiago Gil Roldán</author>
// <email>mailto:santiago.gil2@softwareone.com</email>
// <summary>API RestFull to expose the methods of the entity [ShippingAddress]</summary>
using Microsoft.AspNetCore.Authorization;

namespace SoftwareOne.BaseLine.Api.Controllers
{
    /// <summary>
    /// API RestFull to expose the methods of the entity [ShippingAddress]
    /// </summary>
    public partial class ShippingAddressController
    {
        /// <summary>
        /// Constructor to initialize the application services and the default context instance for the entity (ShippingAddress).
        /// </summary>
        public ShippingAddressController(
                                    Interfaces.ApplicationServices.Facade.IShippingAddress facadeShippingAddress,
                                    IAuthorizationService AuthorizationService
            ) : base(facadeShippingAddress, AuthorizationService)
        {
            this.OrderDefaultEntity = nameof(Entities.ShippingAddress.Name);
        }
    }
}