using FluentValidation;
using WebMVCApplication.Models;

namespace WebMVCApplication.Validator
{
    public class InstructorValidator: AbstractValidator<Instructor>
    {
        public InstructorValidator()
        {
            RuleFor(i => i.Name)
                .NotEmpty()
                .WithMessage("Instructor name is not empty")
                .MaximumLength(100)
                .WithMessage("Instructor name cannot exceed 100 characters.");

            RuleFor(i => i.Address)
                .MaximumLength(200)
                .WithMessage("Address cannot exceed 200 characters.");

            RuleFor(i => i.Image)
                   .MaximumLength(500)
                   .WithMessage("Image Url cannot exceed 500 characters.");
            RuleFor(i => i.Salary)
                .GreaterThan(0)
                    .WithMessage("Salary must be greater than zero.");


        }
    }
}
