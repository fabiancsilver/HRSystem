using FluentValidation;

namespace HRSystem.Application.Features.EmailTypes.Commands.CreateEmailType
{
    public class CreateEmailTypeCommandValidator : AbstractValidator<CreateEmailTypeCommand>
    {
        public CreateEmailTypeCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(128).WithMessage("{PropertyName} must not exceed 128 characters.");
        }
    }
}
