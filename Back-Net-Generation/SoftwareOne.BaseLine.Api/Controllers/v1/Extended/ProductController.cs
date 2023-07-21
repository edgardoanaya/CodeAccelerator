// <copyright company="SoftwareOne">Copyright(c) 2023 All Rights Reserved.</copyright>
// <author>Santiago Gil Roldán</author>
// <email>mailto:santiago.gil2@softwareone.com</email>
// <summary>API RestFull to expose the methods of the entity [Product]</summary>
using Microsoft.AspNetCore.Authorization;

namespace SoftwareOne.BaseLine.Api.Controllers
{
    /// <summary>
    /// API RestFull to expose the methods of the entity [Product]
    /// </summary>
    public partial class ProductController
    {
        /// <summary>
        /// Constructor to initialize the application services and the default context instance for the entity (Product).
        /// </summary>
        public ProductController(
                                    Interfaces.ApplicationServices.Facade.IProduct facadeProduct,
                                    IAuthorizationService AuthorizationService
            ) : base(facadeProduct, AuthorizationService)
        {
            this.OrderDefaultEntity = nameof(Entities.Product.Name);
        }
    }
}