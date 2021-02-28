using AutoMapper;
using HRSystem.Application.Contracts.Persistence.Infrastructure;
using HRSystem.Domain.HR;
using HRSystem.Domain.Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Notifications.Queries.GetNotification
{
    public class GetNotificationQueryHandler : IRequestHandler<GetNotificationQuery, GetNotificationVm>
    {
        private readonly IInfrastructureAsyncRepository<Notification> _notificationRepository;

        private readonly IMapper _mapper;

        public GetNotificationQueryHandler(IMapper mapper, IInfrastructureAsyncRepository<Notification> notificationRepository)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;
        }

        public async Task<GetNotificationVm> Handle(GetNotificationQuery request, CancellationToken cancellationToken)
        {
            var notification = await _notificationRepository.GetById(request.NotificationID);
            var notificationVm = _mapper.Map<GetNotificationVm>(notification);

            return notificationVm;
        }
    }
}
