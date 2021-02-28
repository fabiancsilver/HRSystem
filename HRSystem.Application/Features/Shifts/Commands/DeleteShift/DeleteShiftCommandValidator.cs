using FluentValidation;

namespace HRSystem.Application.Features.Shifts.Commands.DeleteShift
{
    public class DeleteShiftCommandValidator : AbstractValidator<DeleteShiftCommand>
    {
        public DeleteShiftCommandValidator()
        {
            RuleFor(p => p.ShiftID)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
