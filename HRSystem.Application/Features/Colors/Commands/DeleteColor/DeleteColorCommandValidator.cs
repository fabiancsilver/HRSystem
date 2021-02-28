using FluentValidation;

namespace HRSystem.Application.Features.Colors.Commands.DeleteColor
{
    public class DeleteColorCommandValidator : AbstractValidator<DeleteColorCommand>
    {
        public DeleteColorCommandValidator()
        {
            RuleFor(p => p.ColorID)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
