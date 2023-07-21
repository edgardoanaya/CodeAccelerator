//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// <copyright company="SoftwareOne">Copyright(c) 2023 All Rights Reserved.</copyright>
// <author>Jessica Antía Hortúa</author>
// <email>mailto:jessica.antia@softwareone.com</email>
// <summary>Class of the implementation of the services of the application for the Entity (Audit)</summary>
using Base.Application.Validators;

namespace SoftwareOne.BaseLine.ApplicationServices.Services
{
    /// <summary>
    /// Class of the implementation of the services of the application for the Entity (Audit)
    /// </summary>
    public partial class Audit :
        Core.Services.BaseApplicationServices<Entities.Audit,
                                              Interfaces.DataAccess.IAudit, 
                                              Base.Application.Validators.Audit>,
        Interfaces.ApplicationServices.Services.IAudit
    {
        /// <summary>
        /// Constructor to initialize the data access layer, Context Instance [Audit].
        /// </summary>
        /// <param name="repositoryContext">Data Access Context Instance</param>
        public Audit(Interfaces.DataAccess.IAudit repositoryContext, Core.ProcessServicesApplication.IProcessServicesApplication processServicesApplication, Base.Application.Validators.Audit validator)
            : base(repositoryContext, processServicesApplication, validator) { }
    }
}