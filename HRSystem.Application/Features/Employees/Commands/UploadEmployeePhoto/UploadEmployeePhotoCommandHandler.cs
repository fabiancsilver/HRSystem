using AutoMapper;
using HRSystem.Application.Contracts.Infrastructure;
using HRSystem.Application.Contracts.Persistence.HR;
using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Employees.Commands.UploadEmployeePhoto
{
    public class UploadEmployeePhotoCommandHandler : IRequestHandler<UploadEmployeePhotoCommand, UploadEmployeePhotoCommandResponse>
    {

        private readonly IMapper _mapper;
        private IEmployeeRepository _employeeRepository;
        private readonly INotificationService _notificationService;

        public UploadEmployeePhotoCommandHandler(IMapper mapper, 
                                                 IEmployeeRepository employeeRepository,
                                                 INotificationService notificationService)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _notificationService = notificationService;
        }

        public async Task<UploadEmployeePhotoCommandResponse> Handle(UploadEmployeePhotoCommand request,
                                                                     CancellationToken cancellationToken)
        {
            var response = new UploadEmployeePhotoCommandResponse();
            
            var validator = new UploadEmployeePhotoCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            var fileSystemName = $"{Guid.NewGuid()}{request.FileExtension}";
            var fullName = Path.Combine(request.PathToSave, $"{fileSystemName}");

            using (var stream = new FileStream(fullName, FileMode.Create))
            {
                request.Stream.CopyTo(stream);
            }

            await this._employeeRepository.UpdatePhoto(request.EmployeeID, fileSystemName);
            await this._employeeRepository.SaveChanges();
            response.FileSystemNameWithExtenstion = fileSystemName;

            try
            {
                _notificationService.SendNotificaion("EMPLOYEE_NEWPHOTO");
            }
            catch (Exception)
            {
                //Log error
            }

            return response;
        }
    }
}
