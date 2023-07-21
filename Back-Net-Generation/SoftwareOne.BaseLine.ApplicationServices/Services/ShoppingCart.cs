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
// <summary>Class of the implementation of the services of the application for the Entity (ShoppingCart)</summary>
namespace SoftwareOne.BaseLine.ApplicationServices.Services
{
    /// <summary>
    /// Class of the implementation of the services of the application for the Entity (ShoppingCart)
    /// </summary>
    public partial class ShoppingCart :
        Core.Services.BaseApplicationServices<Entities.ShoppingCart,
                                              Interfaces.DataAccess.IShoppingCart,
                                              Base.Application.Validators.ShoppingCart>,
        Interfaces.ApplicationServices.Services.IShoppingCart
    {
        /// <summary>
        /// Constructor to initialize the data access layer, Context Instance [ShoppingCart].
        /// </summary>
        /// <param name="repositoryContext">Data Access Context Instance</param>
        public ShoppingCart(Interfaces.DataAccess.IShoppingCart repositoryContext, Core.ProcessServicesApplication.IProcessServicesApplication processServicesApplication, Base.Application.Validators.ShoppingCart validator)
            : base(repositoryContext, processServicesApplication, validator) { }
    }
}