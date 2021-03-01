using AutoMapper;
using HRSystem.Application.Common;
using HRSystem.Application.Contracts.Persistence.Infrastructure;
using HRSystem.Domain.Infrastructure;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Notifications.Queries.GetNotifications
{
    public class GetNotificationsQueryHandler : IRequestHandler<GetNotificationsQuery, IEnumerable<GetNotificationsVm>>
    {
        private readonly IInfrastructureAsyncRepository<Notification> _notificationRepository;

        private readonly IMapper _mapper;

        public GetNotificationsQueryHandler(IMapper mapper, IInfrastructureAsyncRepository<Notification> notificationRepository)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;
        }

        public async Task<IEnumerable<GetNotificationsVm>> Handle(GetNotificationsQuery request, CancellationToken cancellationToken)
        {
            QueryParameters queryParameters = request.queryParameters;

            var notifications = await _notificationRepository.GetAll(queryParameters);
            var notificationsVm = _mapper.Map<IEnumerable<GetNotificationsVm>>(notifications);

            return notificationsVm;
        }
    }
}
