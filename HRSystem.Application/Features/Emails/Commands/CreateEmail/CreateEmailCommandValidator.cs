using FluentValidation;

namespace HRSystem.Application.Features.Emails.Commands.CreateEmail
{
    public class CreateEmailCommandValidator : AbstractValidator<CreateEmailCommand>
    {
        public CreateEmailCommandValidator()
        {
            RuleFor(p => p.EmailAddress)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(128).WithMessage("{PropertyName} must not exceed 128 characters.");

        }
    }
}
