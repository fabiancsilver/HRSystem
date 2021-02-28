using FluentValidation;

namespace HRSystem.Application.Features.Phones.Commands.UpdatePhone
{
    public class UpdatePhoneCommandValidator : AbstractValidator<UpdatePhoneCommand>
    {
        public UpdatePhoneCommandValidator()
        {
            RuleFor(p => p.PhoneNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(128).WithMessage("{PropertyName} must not exceed 128 characters.");

        }
    }
}
