using FluentValidation;

namespace HRSystem.Application.Features.PhoneTypes.Commands.UpdatePhoneType
{
    public class UpdatePhoneTypeCommandValidator : AbstractValidator<UpdatePhoneTypeCommand>
    {
        public UpdatePhoneTypeCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(128).WithMessage("{PropertyName} must not exceed 128 characters.");
        }
    }
}
