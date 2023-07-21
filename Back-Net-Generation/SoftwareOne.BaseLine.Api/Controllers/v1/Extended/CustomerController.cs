// <copyright company="SoftwareOne">Copyright(c) 2023 All Rights Reserved.</copyright>
// <author>Santiago Gil Roldán</author>
// <email>mailto:santiago.gil2@softwareone.com</email>
// <summary>API RestFull to expose the methods of the entity [Customer]</summary>
using Microsoft.AspNetCore.Authorization;

namespace SoftwareOne.BaseLine.Api.Controllers
{
    /// <summary>
    /// API RestFull to expose the methods of the entity [Customer]
    /// </summary>
    public partial class CustomerController
    {
        /// <summary>
        /// Constructor to initialize the application services and the default context instance for the entity (Customer).
        /// </summary>
        public CustomerController(
                                    Interfaces.ApplicationServices.Facade.ICustomer facadeCustomer,
                                    IAuthorizationService AuthorizationService
            ) : base(facadeCustomer, AuthorizationService)
        {
            this.OrderDefaultEntity = nameof(Entities.Customer.Name);
        }
    }
}