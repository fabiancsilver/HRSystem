using AutoMapper;
using HRSystem.Application.Contracts.Persistence.Infrastructure;
using HRSystem.Domain.HR;
using HRSystem.Domain.Infrastructure;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Permissions.Commands.UpdatePermission
{
    public class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand, UpdatePermissionCommandResponse>
    {
        private readonly IInfrastructureAsyncRepository<Permission> _permissionRepository;
        private readonly IMapper _mapper;

        public UpdatePermissionCommandHandler(IMapper mapper, IInfrastructureAsyncRepository<Permission> permissionRepository)
        {
            _mapper = mapper;
            _permissionRepository = permissionRepository;
        }

        public async Task<UpdatePermissionCommandResponse> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdatePermissionCommandResponse();

            var validator = new UpdatePermissionCommandValidator();
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
                _permissionRepository.Update(permission.PermissionID, permission);
                await _permissionRepository.SaveChanges();

                response.Permission = _mapper.Map<UpdatePermissionDto>(permission);
            }

            return response;
        }
    }
}
