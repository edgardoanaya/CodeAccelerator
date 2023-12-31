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
// <summary>Implementation class for the facade of the application services for the Entity (Menu)</summary>
using SoftwareOne.BaseLine.Interfaces.ApplicationServices.Facade;

namespace SoftwareOne.BaseLine.ApplicationServices.Facade
{
    /// <summary>
    /// Implementation class for the facade of the application services for the Entity (Menu)
    /// </summary>
    public partial class Menu :
        Core.Facade.BaseApplicationFacade<Entities.Menu,
                                     EntitiesDto.Menu,
                                     Interfaces.ApplicationServices.Services.IMenu>,
        Interfaces.ApplicationServices.Facade.IMenu
    {
        /// <summary>
        /// Constructor to initialize the application services layer, Context Instance [Menu].
        /// </summary>
        /// <param name="applicationServices">Context instance for application services</param>
        public Menu(Interfaces.ApplicationServices.Services.IMenu applicationServices) : base(applicationServices) { }

        List<EntitiesDto.Menu> IMenu.GetMenuByRole(int RoleId)
        {
            return _mapper.Map<List<EntitiesDto.Menu>>(this.applicationServicesEntity.GetMenuByRole(RoleId));
        }
    }
}