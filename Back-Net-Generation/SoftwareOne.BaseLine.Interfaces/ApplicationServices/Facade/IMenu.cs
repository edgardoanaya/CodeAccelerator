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
// <summary>This Interface represents the Facade Implementations for the application services for the Entity (Menu)</summary>
namespace SoftwareOne.BaseLine.Interfaces.ApplicationServices.Facade
{
    /// <summary>
    /// This Interface represents the Facade Implementations for the application services for the Entity(Menu)
    /// </summary>
    public partial interface IMenu : Core.Facade.IBaseApplicationFacade<Entities.Menu, EntitiesDto.Menu> {
        public List<EntitiesDto.Menu> GetMenuByRole(int RoleId);
    }
}