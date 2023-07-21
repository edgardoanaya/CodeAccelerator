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
// <summary>Validator implementation for the Entity (Audit)</summary>
using FluentValidation;
using SoftwareOne.BaseLine.Core.Validator;
using SoftwareOne.BaseLine.ApplicationTexts;

namespace Base.Application.Validators
{
    public class Audit : SwoValidator<SoftwareOne.BaseLine.Entities.Audit>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Audit"/> class.
        /// </summary>
        public Audit()
        {
            // Entity is mandatory
            RuleFor(category => category.Entity)
                .NotNull().WithMessage(ResourceValidations.FieldCantBeNull)
                .NotEmpty().WithMessage(ResourceValidations.FieldCantBeEmpty);
        }
    }
}