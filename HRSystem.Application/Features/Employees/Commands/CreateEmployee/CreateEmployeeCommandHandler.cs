using AutoMapper;
using HRSystem.Application.Contracts.Infrastructure;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, CreateEmployeeCommandResponse>
    {
        private readonly IHRAsyncRepository<Employee> _employeeRepository;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IMapper mapper,     
                                            IHRAsyncRepository<Employee> employeeRepository,
                                            INotificationService notificationService)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _notificationService = notificationService;
        }

        public async Task<CreateEmployeeCommandResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateEmployeeCommandResponse();

            var validator = new CreateEmployeeCommandValidator();
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
                _employeeRepository.Create(employee);
                await _employeeRepository.SaveChanges();

                response.Employee = _mapper.Map<CreateEmployeeDto>(employee);

                try
                {
                    _notificationService.SendNotificaion("EMPLOYEE_ADDED");
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
