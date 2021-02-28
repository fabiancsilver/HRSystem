using FluentValidation;

namespace HRSystem.Application.Features.AddressTypes.Commands.UpdateAddressType
{
    public class UpdateAddressTypeCommandValidator : AbstractValidator<UpdateAddressTypeCommand>
    {
        public UpdateAddressTypeCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(128).WithMessage("{PropertyName} must not exceed 128 characters.");
        }
    }
}
