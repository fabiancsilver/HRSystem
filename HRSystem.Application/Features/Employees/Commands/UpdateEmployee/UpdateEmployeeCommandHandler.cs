using AutoMapper;
using HRSystem.Application.Contracts.Infrastructure;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, UpdateEmployeeCommandResponse>
    {
        private readonly IHRAsyncRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        public UpdateEmployeeCommandHandler(IMapper mapper, 
                                            IHRAsyncRepository<Employee> employeeRepository,
                                            INotificationService notificationService)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _notificationService = notificationService;
        }

        public async Task<UpdateEmployeeCommandResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateEmployeeCommandResponse();

            var validator = new UpdateEmployeeCommandValidator();
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
                var employee = _mapper.Map<Employee>(request);
                _employeeRepository.Update(employee.EmployeeID, employee);
                await _employeeRepository.SaveChanges();

                response.Employee = _mapper.Map<UpdateEmployeeDto>(employee);
                try
                {
                    _notificationService.SendNotificaion("EMPLOYEE_UPDATED");
                }
                catch (Exception)
                {
                    //Log error
                }
            }

            return response;
        }
    }
}
