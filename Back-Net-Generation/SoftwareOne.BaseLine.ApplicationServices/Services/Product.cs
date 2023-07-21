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
// <summary>Class of the implementation of the services of the application for the Entity (Product)</summary>
namespace SoftwareOne.BaseLine.ApplicationServices.Services
{
    /// <summary>
    /// Class of the implementation of the services of the application for the Entity (Product)
    /// </summary>
    public partial class Product :
        Core.Services.BaseApplicationServices<Entities.Product,
                                              Interfaces.DataAccess.IProduct,
                                              Base.Application.Validators.Product>,
        Interfaces.ApplicationServices.Services.IProduct
    {
        /// <summary>
        /// Constructor to initialize the data access layer, Context Instance [Product].
        /// </summary>
        /// <param name="repositoryContext">Data Access Context Instance</param>
        public Product(Interfaces.DataAccess.IProduct repositoryContext, Core.ProcessServicesApplication.IProcessServicesApplication processServicesApplication, Base.Application.Validators.Product validator)
            : base(repositoryContext, processServicesApplication, validator) { }
    }
}