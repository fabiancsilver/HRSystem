using AutoMapper;
using HRSystem.Application.Contracts.Persistence.Infrastructure;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Notifications.Queries.GetNotifications
{
    public class GetPermissionEmployeesQueryHandler : IRequestHandler<GetPermissionEmployeesQuery, IEnumerable<GetPermissionEmployeesVm>>
    {
        private readonly IPermissionEmployeeRepository _permissionEmployeeRepository;

        private readonly IMapper _mapper;

        public GetPermissionEmployeesQueryHandler(IMapper mapper, IPermissionEmployeeRepository permissionEmployeeRepository)
        {
            _mapper = mapper;
            _permissionEmployeeRepository = permissionEmployeeRepository;
        }

        public async Task<IEnumerable<GetPermissionEmployeesVm>> Handle(GetPermissionEmployeesQuery request, CancellationToken cancellationToken)
        {
            //QueryParameters queryParameters = request.queryParameters;

            var permissionEmployees = await _permissionEmployeeRepository.ByEmployee(request.EmployeeID);
            var permissionEmployeesVm = _mapper.Map<IEnumerable<GetPermissionEmployeesVm>>(permissionEmployees);

            return permissionEmployeesVm;
        }
    }
}
