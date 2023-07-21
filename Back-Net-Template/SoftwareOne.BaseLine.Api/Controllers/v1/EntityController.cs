//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// <copyright company="SoftwareOne">Copyright(c) 2023 All Rights Reserved.</copyright>
// <author>Santiago Gil Roldán</author>
// <email>mailto:santiago.gil2@softwareone.com</email>
// <summary>API RestFull to expose the methods of the entity [Entity]</summary>
using Microsoft.AspNetCore.Mvc;

namespace SoftwareOne.BaseLine.Api.Controllers
{
    /// <summary>
    /// API RestFull to expose the methods of the entity [Entity]
    /// </summary>
    [ApiVersion(Common.Constant.VersionApiv1)]
    public partial class EntityController :
                          Core.Controller.BaseController<Entities.Entity,
                                         EntitiesDto.Entity,
                                         Interfaces.ApplicationServices.Facade.IEntity>
    { }
}