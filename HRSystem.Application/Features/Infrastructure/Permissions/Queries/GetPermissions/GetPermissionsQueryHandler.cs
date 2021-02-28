using AutoMapper;
using HRSystem.Application.Common;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using HRSystem.Domain.Infrastructure;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Permissions.Queries.GetPermissions
{
    public class GetPermissionsQueryHandler : IRequestHandler<GetPermissionsQuery, IEnumerable<GetPermissionsVm>>
    {
        private readonly IHRAsyncRepository<Permission> _notificationRepository;

        private readonly IMapper _mapper;

        public GetPermissionsQueryHandler(IMapper mapper, IHRAsyncRepository<Permission> notificationRepository)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;
        }

        public async Task<IEnumerable<GetPermissionsVm>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
        {
            QueryParameters queryParameters = request.queryParameters;

            var notifications = await _notificationRepository.GetAll(queryParameters);
            var notificationsVm = _mapper.Map<IEnumerable<GetPermissionsVm>>(notifications);

            return notificationsVm;
        }
    }
}
