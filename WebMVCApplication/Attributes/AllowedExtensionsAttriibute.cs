using System.ComponentModel.DataAnnotations;
namespace WebMVCApplication.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _allowedExtensions;

        public AllowedExtensionsAttribute(string[] allowedExtensions)
        {
            _allowedExtensions = allowedExtensions;
        }

        protected override ValidationResult? IsValid(object? value,ValidationContext validationContext)
        {

            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName)
                                     .ToLowerInvariant()
                                     .Trim();

                var allowed = _allowedExtensions
                                .Select(x => x.ToLowerInvariant().Trim());

                if (!allowed.Contains(extension))
                {
                    return new ValidationResult(
                        $"Only {string.Join(", ", _allowedExtensions)} files are allowed.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
