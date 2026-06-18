using FluentValidation;
using WebMVCApplication.Models;

namespace WebMVCApplication.Validator
{
    public class CourseValidator:AbstractValidator<Course>
    {
        public CourseValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Course name is required.")
                .MaximumLength(100)
                .WithMessage("Course name cannot exceed 100 characters.");

            RuleFor(c => c.Degree)
                .GreaterThan(0)
                .WithMessage("Degree must be greater than 0.");

            RuleFor(c => c.MinDegree)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Minimum degree cannot be negative.")
                .LessThan(c => c.Degree)
                .WithMessage("Minimum degree must be less than the course degree.");
        }
    }
}
