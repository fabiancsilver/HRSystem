using FluentValidation;

namespace HRSystem.Application.Features.EmailTypes.Commands.UpdateEmailType
{
    public class UpdateEmailTypeCommandValidator : AbstractValidator<UpdateEmailTypeCommand>
    {
        public UpdateEmailTypeCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(128).WithMessage("{PropertyName} must not exceed 128 characters.");
        }
    }
}
