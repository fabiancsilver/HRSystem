using AutoMapper;
using HRSystem.Application.Contracts.Persistence.Infrastructure;
using HRSystem.Domain.HR;
using HRSystem.Domain.Infrastructure;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Permissions.Commands.DeletePermission
{
    public class DeletePermissionCommandHandler : IRequestHandler<DeletePermissionCommand, DeletePermissionCommandResponse>
    {
        private readonly IInfrastructureAsyncRepository<Permission> _permissionRepository;
        private readonly IMapper _mapper;

        public DeletePermissionCommandHandler(IMapper mapper, IInfrastructureAsyncRepository<Permission> permissionRepository)
        {
            _mapper = mapper;
            _permissionRepository = permissionRepository;
        }

        public async Task<DeletePermissionCommandResponse> Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
        {
            var response = new DeletePermissionCommandResponse();

            var validator = new DeletePermissionCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (response.Success)
            {
                var permission = _mapper.Map<Permission>(request);
                await _permissionRepository.Remove(permission.PermissionID);
                await _permissionRepository.SaveChanges();

                response.Permission = _mapper.Map<DeletePermissionDto>(permission);
            }

            return response;
        }
    }
}
