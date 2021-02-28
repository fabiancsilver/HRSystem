using FluentValidation;

namespace HRSystem.Application.Features.AddressTypes.Commands.CreateAddressType
{
    public class CreateAddressTypeCommandValidator : AbstractValidator<CreateAddressTypeCommand>
    {
        public CreateAddressTypeCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(128).WithMessage("{PropertyName} must not exceed 128 characters.");
        }
    }
}
