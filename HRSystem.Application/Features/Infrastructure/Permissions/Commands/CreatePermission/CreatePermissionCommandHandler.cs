using AutoMapper;
using HRSystem.Application.Contracts.Persistence.Infrastructure;
using HRSystem.Domain.HR;
using HRSystem.Domain.Infrastructure;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Permissions.Commands.CreatePermission
{
    public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, CreatePermissionCommandResponse>
    {
        private readonly IInfrastructureAsyncRepository<Permission> _permissionRepository;
        private readonly IMapper _mapper;

        public CreatePermissionCommandHandler(IMapper mapper, IInfrastructureAsyncRepository<Permission> permissionRepository)
        {
            _mapper = mapper;
            _permissionRepository = permissionRepository;
        }

        public async Task<CreatePermissionCommandResponse> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            var response = new CreatePermissionCommandResponse();

            var validator = new CreatePermissionCommandValidator();
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
                _permissionRepository.Create(permission);
                await _permissionRepository.SaveChanges();

                response.Permission = _mapper.Map<CreatePermissionDto>(permission);
            }

            return response;
        }
    }
}
