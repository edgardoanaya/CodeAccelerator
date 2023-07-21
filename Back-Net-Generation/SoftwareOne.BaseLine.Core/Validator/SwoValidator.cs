using FluentValidation;

namespace SoftwareOne.BaseLine.Core.Validator
{
    /// <summary>
    /// Generic validator.
    /// </summary>
    /// <typeparam name="T">Business entity.</typeparam>
    public class SwoValidator<T> : AbstractValidator<T> { }
}