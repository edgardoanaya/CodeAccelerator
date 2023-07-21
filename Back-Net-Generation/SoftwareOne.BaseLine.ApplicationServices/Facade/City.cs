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
// <summary>Implementation class for the facade of the application services for the Entity (City)</summary>
using AutoMapper;

namespace SoftwareOne.BaseLine.ApplicationServices.Facade
{
    /// <summary>
    /// Implementation class for the facade of the application services for the Entity (City)
    /// </summary>
    public partial class City :
        Core.Facade.BaseApplicationFacade<Entities.City,
                                     EntitiesDto.City,
                                     Interfaces.ApplicationServices.Services.ICity>,
        Interfaces.ApplicationServices.Facade.ICity
    {
        /// <summary>
        /// Constructor to initialize the application services layer, Context Instance [City].
        /// </summary>
        /// <param name="applicationServices">Context instance for application services</param>
        public City(Interfaces.ApplicationServices.Services.ICity applicationServices) : base(applicationServices) {
            _mapper = new Mapper(configMapperFacade);
        }
    }
}