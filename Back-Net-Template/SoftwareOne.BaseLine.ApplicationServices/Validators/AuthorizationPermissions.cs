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
// <summary>Validator implementation for the Entity (AuthorizationPermissions)</summary>
using FluentValidation;
using SoftwareOne.BaseLine.ApplicationTexts;
using SoftwareOne.BaseLine.Core.Validator;

namespace Base.Application.Validators
{
    public class AuthorizationPermissions : SwoValidator<SoftwareOne.BaseLine.Entities.AuthorizationPermissions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationPermissions"/> class.
        /// </summary>
        public AuthorizationPermissions()
        {
            // Entity Id mandatory
            RuleFor(entity => entity.EntityId)
                .NotNull().WithMessage(ResourceValidations.FieldCantBeNull)
                .NotEmpty().WithMessage(ResourceValidations.FieldCantBeEmpty);
            // Role Id mandatory
            RuleFor(entity => entity.RoleId)
                .NotNull().WithMessage(ResourceValidations.FieldCantBeNull)
                .NotEmpty().WithMessage(ResourceValidations.FieldCantBeEmpty);
        }
    }
}