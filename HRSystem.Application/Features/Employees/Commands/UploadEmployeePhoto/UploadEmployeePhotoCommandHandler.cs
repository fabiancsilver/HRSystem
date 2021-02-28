using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Employees.Commands.UploadEmployeePhoto
{
    public class UploadEmployeePhotoCommandHandler : IRequestHandler<UploadEmployeePhotoCommand, UploadEmployeePhotoCommandResponse>
    {
        
        private readonly IMapper _mapper;
        private IEmployeeRepository _employeeRepository;

        public UploadEmployeePhotoCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;            
            _employeeRepository = employeeRepository;
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

            return response;
        }
    }
}
