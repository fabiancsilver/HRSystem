using FluentValidation;

namespace HRSystem.Application.Features.AddressTypes.Commands.DeleteAddressType
{
    public class DeleteAddressTypeCommandValidator : AbstractValidator<DeleteAddressTypeCommand>
    {
        public DeleteAddressTypeCommandValidator()
        {
            RuleFor(p => p.AddressTypeID)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
