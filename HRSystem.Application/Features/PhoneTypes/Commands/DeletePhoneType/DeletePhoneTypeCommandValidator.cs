using FluentValidation;

namespace HRSystem.Application.Features.PhoneTypes.Commands.DeletePhoneType
{
    public class DeletePhoneTypeCommandValidator : AbstractValidator<DeletePhoneTypeCommand>
    {
        public DeletePhoneTypeCommandValidator()
        {
            RuleFor(p => p.PhoneTypeID)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
