using System.ComponentModel.DataAnnotations;

namespace WebMVCApplication.Attributes
{
    public class LessThanAttribute : ValidationAttribute
    {

        private readonly string _otherProperty;

        public LessThanAttribute(string otherProperty)
        {
            _otherProperty = otherProperty;
        }

        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            var otherProperty = validationContext.ObjectType
                .GetProperty(_otherProperty);

            if (otherProperty == null)
                return new ValidationResult("Property not found.");

            var otherValue = otherProperty.GetValue(validationContext.ObjectInstance);

            if (value is double current &&
                otherValue is double other &&
                current >= other)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
