// <copyright company="SoftwareOne">Copyright(c) 2023 All Rights Reserved.</copyright>
// <author>Santiago Gil Roldán</author>
// <email>mailto:santiago.gil2@softwareone.com</email>
// <summary>API RestFull to expose the methods of the entity [State]</summary>
using Microsoft.AspNetCore.Authorization;

namespace SoftwareOne.BaseLine.Api.Controllers
{
    /// <summary>
    /// API RestFull to expose the methods of the entity [State]
    /// </summary>
    public partial class StateController
    {
        /// <summary>
        /// Constructor to initialize the application services and the default context instance for the entity (State).
        /// </summary>
        public StateController(
                                    Interfaces.ApplicationServices.Facade.IState facadeState,
                                    IAuthorizationService AuthorizationService
            ) : base(facadeState, AuthorizationService)
        {
            this.OrderDefaultEntity = nameof(Entities.State.Name);
        }
    }
}