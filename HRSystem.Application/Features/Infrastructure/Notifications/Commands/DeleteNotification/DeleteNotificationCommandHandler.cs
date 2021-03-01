using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.Infrastructure;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Notifications.Commands.DeleteNotification
{
    public class DeleteNotificationCommandHandler : IRequestHandler<DeleteNotificationCommand, DeleteNotificationCommandResponse>
    {
        private readonly IHRAsyncRepository<Notification> _notificationRepository;
        private readonly IMapper _mapper;

        public DeleteNotificationCommandHandler(IMapper mapper, IHRAsyncRepository<Notification> notificationRepository)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;
        }

        public async Task<DeleteNotificationCommandResponse> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteNotificationCommandResponse();

            var validator = new DeleteNotificationCommandValidator();
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
                await _notificationRepository.Remove(notification.NotificationID);
                await _notificationRepository.SaveChanges();

                response.Notification = _mapper.Map<DeleteNotificationDto>(notification);
            }

            return response;
        }
    }
}
