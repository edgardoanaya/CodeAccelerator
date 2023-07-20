using System;
using System.Collections.Generic;

namespace CodeGenerator.Engine
{
    public class Tag : Variable
    {
        public Tag(string name, string contentReplace, string variableNewText) : base(name, contentReplace, variableNewText)
        {
        }

        public override string Replace(string contenido, object entity)
        {
            string textReplaced = contenido;
            string valueVariable = string.Empty;

            if (this.Name.Contains("{DecoratorField}"))
            {
                Field field = (Field)entity;
                if (!string.IsNullOrEmpty(field.ForeignKey))
                {
                    valueVariable = @"[ForeignKey(""Entity"")]";
                    valueVariable = valueVariable.Replace("Entity", field.ForeignKey);
                }
                else if (!string.IsNullOrEmpty(field.Decorator))
                {
                    valueVariable = field.Decorator;
                }

            }
            else if (this.Name.Contains("{DefaultField}"))
            {
                Field field = (Field)entity;
                if (!string.IsNullOrEmpty(field.Default))
                {
                    valueVariable = @"= Default;";
                    valueVariable = valueVariable.Replace("Default", field.Default);
                }            
            }
            else if (this.Name.Contains("{MaxLengthField}"))
            {
                Field field = (Field)entity;
                if (!string.IsNullOrEmpty(field.MaxLength))
                {
                    valueVariable = @"
                builder.Property(e => e.Name)
                    .HasMaxLength(MAX_LENGTH)
                    .IsUnicode(false);";
                    valueVariable = valueVariable.Replace("Name", field.Name);
                    valueVariable = valueVariable.Replace("MAX_LENGTH", field.MaxLength);
                }

                if (field.IsRequired)
                {
                    valueVariable += @"
                 builder.Property(e => e.Name)
                    .IsRequired(true)
                    .IsUnicode(false);";
                    valueVariable = valueVariable.Replace("Name", field.Name);
                }
            }
            else if (this.Name.Contains("{ValidatorsIsRequiredField}"))
            {
                Field field = (Field)entity;
                if (field.IsRequired)
                {
                    valueVariable = @"// Name is mandatory
                 RuleFor(entity => entity.Name)
                    .NotNull().WithMessage(ResourceValidations.FieldCantBeNull)
                    .NotEmpty().WithMessage(ResourceValidations.FieldCantBeEmpty);";
                    valueVariable = valueVariable.Replace("Name", field.Name);
                }
            }
            else if (this.Name.Contains("{ValidatorsMaxLengthField}"))
            {
                Field field = (Field)entity;
                if (!string.IsNullOrEmpty(field.MaxLength))
                {
                    valueVariable = @"// Name has lenght validation
                 RuleFor(entity => entity.Name)
                    .Length(0, MAX_LENGTH).WithMessage(ResourceValidations.InvalidLength);";
                    valueVariable = valueVariable.Replace("Name", field.Name);
                    valueVariable = valueVariable.Replace("MAX_LENGTH", field.MaxLength);
                }
            }
            else if (this.Name.Contains("{ValidatorsPrecisionField}"))
            {
                Field field = (Field)entity;
                if (!string.IsNullOrEmpty(field.Precision))
                {
                    valueVariable = @"// Name has Precision validation
                 RuleFor(entity => entity.Name)
                    .ScalePrecision(VALUE_PRECISION).WithMessage(ResourceValidations.InvalidDecimal);";
                    valueVariable = valueVariable.Replace("Name", field.Name);
                    valueVariable = valueVariable.Replace("VALUE_PRECISION", field.Precision);
                }
            }
            textReplaced = contenido.Replace(this.Name, valueVariable);

            return textReplaced;
        }


    }
}

