using FluentValidation;

namespace HRSystem.Application.Features.PhoneTypes.Commands.CreatePhoneType
{
    public class CreatePhoneTypeCommandValidator : AbstractValidator<CreatePhoneTypeCommand>
    {
        public CreatePhoneTypeCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(128).WithMessage("{PropertyName} must not exceed 128 characters.");
        }
    }
}
