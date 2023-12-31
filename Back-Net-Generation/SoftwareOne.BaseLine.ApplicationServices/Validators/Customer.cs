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
// <summary>Validator implementation for the Entity (Customer)</summary>
using FluentValidation;
using SoftwareOne.BaseLine.ApplicationTexts;
using SoftwareOne.BaseLine.Core.Validator;

namespace Base.Application.Validators
{
    public class Customer : SwoValidator<SoftwareOne.BaseLine.Entities.Customer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        public Customer()
        {
            // Name is mandatory
                 RuleFor(entity => entity.Name)
                    .NotNull().WithMessage(ResourceValidations.FieldCantBeNull)
                    .NotEmpty().WithMessage(ResourceValidations.FieldCantBeEmpty);
            // Name has lenght validation
                 RuleFor(entity => entity.Name)
                    .Length(0, 50).WithMessage(ResourceValidations.InvalidLength);
            // Email is mandatory
                 RuleFor(entity => entity.Email)
                    .NotNull().WithMessage(ResourceValidations.FieldCantBeNull)
                    .NotEmpty().WithMessage(ResourceValidations.FieldCantBeEmpty);
            // Email has lenght validation
                 RuleFor(entity => entity.Email)
                    .Length(0, 100).WithMessage(ResourceValidations.InvalidLength);
            // RegistrationDate is mandatory
                 RuleFor(entity => entity.RegistrationDate)
                    .NotNull().WithMessage(ResourceValidations.FieldCantBeNull)
                    .NotEmpty().WithMessage(ResourceValidations.FieldCantBeEmpty);
            
            
            
            
            
            
            
            
            
            
            
            

        }
    }
}