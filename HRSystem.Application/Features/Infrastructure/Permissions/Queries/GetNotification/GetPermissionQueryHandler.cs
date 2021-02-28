using AutoMapper;
using HRSystem.Application.Contracts.Persistence.Infrastructure;
using HRSystem.Domain.HR;
using HRSystem.Domain.Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Permissions.Queries.GetPermission
{
    public class GetPermissionQueryHandler : IRequestHandler<GetPermissionQuery, GetPermissionVm>
    {
        private readonly IInfrastructureAsyncRepository<Permission> _permissionRepository;

        private readonly IMapper _mapper;

        public GetPermissionQueryHandler(IMapper mapper, IInfrastructureAsyncRepository<Permission> permissionRepository)
        {
            _mapper = mapper;
            _permissionRepository = permissionRepository;
        }

        public async Task<GetPermissionVm> Handle(GetPermissionQuery request, CancellationToken cancellationToken)
        {
            var permission = await _permissionRepository.GetById(request.PermissionID);
            var permissionVm = _mapper.Map<GetPermissionVm>(permission);

            return permissionVm;
        }
    }
}
