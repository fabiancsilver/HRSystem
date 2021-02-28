using FluentValidation;

namespace HRSystem.Application.Features.Positions.Commands.DeletePosition
{
    public class DeletePositionCommandValidator : AbstractValidator<DeletePositionCommand>
    {
        public DeletePositionCommandValidator()
        {
            RuleFor(p => p.PositionID)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
