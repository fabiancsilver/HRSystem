using FluentValidation;

namespace HRSystem.Application.Features.Permissions.Commands.DeletePermission
{
    public class DeletePermissionCommandValidator : AbstractValidator<DeletePermissionCommand>
    {
        public DeletePermissionCommandValidator()
        {
            RuleFor(p => p.PermissionID)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
