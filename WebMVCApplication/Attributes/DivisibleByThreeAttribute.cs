using System.ComponentModel.DataAnnotations;

namespace WebMVCApplication.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DivisibleByThreeAttribute :ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is int hours)
                return hours % 3 == 0;

            return false;
        }

    }
}
