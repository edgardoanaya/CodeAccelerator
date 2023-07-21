// <copyright company="SoftwareOne">Copyright(c) 2023 All Rights Reserved.</copyright>
// <author>Santiago Gil Roldán</author>
// <email>mailto:santiago.gil2@softwareone.com</email>
// <summary>API RestFull to expose the methods of the entity [Category]</summary>
using Microsoft.AspNetCore.Authorization;

namespace SoftwareOne.BaseLine.Api.Controllers
{
    /// <summary>
    /// API RestFull to expose the methods of the entity [Category]
    /// </summary>
    public partial class CategoryController
    {
        /// <summary>
        /// Constructor to initialize the application services and the default context instance for the entity (Category).
        /// </summary>
        public CategoryController(
                                    Interfaces.ApplicationServices.Facade.ICategory facadeCategory,
                                    IAuthorizationService AuthorizationService
            ) : base(facadeCategory, AuthorizationService)
        {
            this.OrderDefaultEntity = nameof(Entities.Category.Name);
        }
    }
}