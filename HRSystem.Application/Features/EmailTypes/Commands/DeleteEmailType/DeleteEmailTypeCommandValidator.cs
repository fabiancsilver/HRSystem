using FluentValidation;

namespace HRSystem.Application.Features.EmailTypes.Commands.DeleteEmailType
{
    public class DeleteEmailTypeCommandValidator : AbstractValidator<DeleteEmailTypeCommand>
    {
        public DeleteEmailTypeCommandValidator()
        {
            RuleFor(p => p.EmailTypeID)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
