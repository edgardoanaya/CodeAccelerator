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
// <summary>Class of the implementation of the services of the application for the Entity (AuthorizationPermissions)</summary>
namespace SoftwareOne.BaseLine.ApplicationServices.Services
{
    /// <summary>
    /// Class of the implementation of the services of the application for the Entity (AuthorizationPermissions)
    /// </summary>
    public partial class AuthorizationPermissions :
        Core.Services.BaseApplicationServices<Entities.AuthorizationPermissions,
                                              Interfaces.DataAccess.IAuthorizationPermissions,
                                              Base.Application.Validators.AuthorizationPermissions>,
        Interfaces.ApplicationServices.Services.IAuthorizationPermissions
    {
        /// <summary>
        /// Constructor to initialize the data access layer, Context Instance [AuthorizationPermissions].
        /// </summary>
        /// <param name="repositoryContext">Data Access Context Instance</param>
        public AuthorizationPermissions(Interfaces.DataAccess.IAuthorizationPermissions repositoryContext, Core.ProcessServicesApplication.IProcessServicesApplication processServicesApplication, Base.Application.Validators.AuthorizationPermissions validator)
            : base(repositoryContext, processServicesApplication, validator) { }
    }
}