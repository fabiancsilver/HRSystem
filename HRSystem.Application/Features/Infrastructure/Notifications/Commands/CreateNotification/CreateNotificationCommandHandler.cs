using AutoMapper;
using HRSystem.Application.Contracts.Persistence.Infrastructure;
using HRSystem.Domain.Infrastructure;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Notifications.Commands.CreateNotification
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, CreateNotificationCommandResponse>
    {
        private readonly IInfrastructureAsyncRepository<Notification> _notificationRepository;
        private readonly IMapper _mapper;

        public CreateNotificationCommandHandler(IMapper mapper, IInfrastructureAsyncRepository<Notification> notificationRepository)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;
        }

        public async Task<CreateNotificationCommandResponse> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateNotificationCommandResponse();

            var validator = new CreateNotificationCommandValidator();
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
                _notificationRepository.Create(notification);
                await _notificationRepository.SaveChanges();

                response.Notification = _mapper.Map<CreateNotificationDto>(notification);
            }

            return response;
        }
    }
}
