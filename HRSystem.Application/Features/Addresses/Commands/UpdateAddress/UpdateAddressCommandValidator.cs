using FluentValidation;

namespace HRSystem.Application.Features.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
    {
        public UpdateAddressCommandValidator()
        {
            RuleFor(p => p.Line1)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(128).WithMessage("{PropertyName} must not exceed 128 characters.");

            RuleFor(p => p.City)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(32).WithMessage("{PropertyName} must not exceed 128 characters.");

            RuleFor(p => p.State)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(32).WithMessage("{PropertyName} must not exceed 128 characters.");

            RuleFor(p => p.Country)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(32).WithMessage("{PropertyName} must not exceed 128 characters.");

            RuleFor(p => p.ZipCode)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(32).WithMessage("{PropertyName} must not exceed 128 characters.");
        }
    }
}
