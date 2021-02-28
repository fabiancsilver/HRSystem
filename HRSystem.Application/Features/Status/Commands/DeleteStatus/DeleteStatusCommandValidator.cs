using FluentValidation;

namespace HRSystem.Application.Features.Statuses.Commands.DeleteStatus
{
    public class DeleteStatusCommandValidator : AbstractValidator<DeleteStatusCommand>
    {
        public DeleteStatusCommandValidator()
        {
            RuleFor(p => p.StatusID)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
