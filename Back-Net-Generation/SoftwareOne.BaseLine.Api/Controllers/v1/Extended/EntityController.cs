// <copyright company="SoftwareOne">Copyright(c) 2023 All Rights Reserved.</copyright>
// <author>Santiago Gil Roldán</author>
// <email>mailto:santiago.gil2@softwareone.com</email>
// <summary>API RestFull to expose the methods of the entity [Entity]</summary>
using Microsoft.AspNetCore.Authorization;

namespace SoftwareOne.BaseLine.Api.Controllers
{
    /// <summary>
    /// API RestFull to expose the methods of the entity [Entity]
    /// </summary>
    public partial class EntityController
    {
        /// <summary>
        /// Constructor to initialize the application services and the default context instance for the entity (Entity).
        /// </summary>
        public EntityController(
                                    Interfaces.ApplicationServices.Facade.IEntity facadeEntity,
                                    IAuthorizationService AuthorizationService
            ) : base(facadeEntity, AuthorizationService)
        {
            this.OrderDefaultEntity = nameof(Entities.Entity.Name);
        }
    }
}