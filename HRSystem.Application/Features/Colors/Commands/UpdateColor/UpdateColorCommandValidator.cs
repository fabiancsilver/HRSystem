using FluentValidation;

namespace HRSystem.Application.Features.Colors.Commands.UpdateColor
{
    public class UpdateColorCommandValidator : AbstractValidator<UpdateColorCommand>
    {
        public UpdateColorCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(128).WithMessage("{PropertyName} must not exceed 128 characters.");
        }
    }
}
