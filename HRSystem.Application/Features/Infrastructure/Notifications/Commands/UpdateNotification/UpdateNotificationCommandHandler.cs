using AutoMapper;
using HRSystem.Application.Contracts.Persistence.Infrastructure;
using HRSystem.Domain.HR;
using HRSystem.Domain.Infrastructure;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Notifications.Commands.UpdateNotification
{
    public class UpdateNotificationCommandHandler : IRequestHandler<UpdateNotificationCommand, UpdateNotificationCommandResponse>
    {
        private readonly IInfrastructureAsyncRepository<Notification> _notificationRepository;
        private readonly IMapper _mapper;

        public UpdateNotificationCommandHandler(IMapper mapper, IInfrastructureAsyncRepository<Notification> notificationRepository)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;
        }

        public async Task<UpdateNotificationCommandResponse> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateNotificationCommandResponse();

            var validator = new UpdateNotificationCommandValidator();
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
                var notification = _mapper.Map<Notification>(request);
                _notificationRepository.Update(notification.NotificationID, notification);
                await _notificationRepository.SaveChanges();

                response.Notification = _mapper.Map<UpdateNotificationDto>(notification);
            }

            return response;
        }
    }
}
