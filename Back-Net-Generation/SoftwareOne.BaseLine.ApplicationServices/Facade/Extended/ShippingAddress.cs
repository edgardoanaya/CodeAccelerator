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
// <summary>Implementation class for the facade of the application services for the Entity (ShippingAddress)</summary>
using AutoMapper;

namespace SoftwareOne.BaseLine.ApplicationServices.Facade
{
    /// <summary>
    /// Implementation class for the extended facade of the application services for the Entity (ShippingAddress)
    /// </summary>
    public partial class ShippingAddress
    {
        protected new readonly MapperConfiguration configMapperFacade =
            new(cfg =>
            {
                cfg.CreateMap<SoftwareOne.BaseLine.Entities.ShippingAddress, SoftwareOne.BaseLine.EntitiesDto.ShippingAddress>();
                cfg.CreateMap<SoftwareOne.BaseLine.EntitiesDto.ShippingAddress, SoftwareOne.BaseLine.Entities.ShippingAddress>();
                cfg.CreateMap<SoftwareOne.BaseLine.Entities.Customer, SoftwareOne.BaseLine.EntitiesDto.Customer>();
                cfg.CreateMap<SoftwareOne.BaseLine.EntitiesDto.Customer, SoftwareOne.BaseLine.Entities.Customer>();
cfg.CreateMap<SoftwareOne.BaseLine.Entities.City, SoftwareOne.BaseLine.EntitiesDto.City>();
                cfg.CreateMap<SoftwareOne.BaseLine.EntitiesDto.City, SoftwareOne.BaseLine.Entities.City>();

            });
    }
}