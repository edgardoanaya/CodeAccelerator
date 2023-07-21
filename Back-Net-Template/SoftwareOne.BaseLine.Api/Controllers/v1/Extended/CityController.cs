// <copyright company="SoftwareOne">Copyright(c) 2023 All Rights Reserved.</copyright>
// <author>Santiago Gil Roldán</author>
// <email>mailto:santiago.gil2@softwareone.com</email>
// <summary>API RestFull to expose the methods of the entity [City]</summary>
using Microsoft.AspNetCore.Authorization;

namespace SoftwareOne.BaseLine.Api.Controllers
{
    /// <summary>
    /// API RestFull to expose the methods of the entity [City]
    /// </summary>
    public partial class CityController
    {
        /// <summary>
        /// Constructor to initialize the application services and the default context instance for the entity (City).
        /// </summary>
        public CityController(
                                    Interfaces.ApplicationServices.Facade.ICity facadeCity,
                                    IAuthorizationService AuthorizationService
            ) : base(facadeCity, AuthorizationService)
        {
            this.OrderDefaultEntity = nameof(Entities.City.Operation);
        }
    }
}