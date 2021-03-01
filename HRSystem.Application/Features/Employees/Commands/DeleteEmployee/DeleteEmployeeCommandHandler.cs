using AutoMapper;
using HRSystem.Application.Contracts.Infrastructure;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, DeleteEmployeeCommandResponse>
    {
        private readonly IHRAsyncRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        public DeleteEmployeeCommandHandler(IMapper mapper, 
                                            IHRAsyncRepository<Employee> employeeRepository,
                                            INotificationService notificationService)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _notificationService = notificationService;
        }

        public async Task<DeleteEmployeeCommandResponse> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteEmployeeCommandResponse();

            var validator = new DeleteEmployeeCommandValidator();
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
                await _employeeRepository.Remove(employee.EmployeeID);
                await _employeeRepository.SaveChanges();

                try
                {
                    _notificationService.SendNotificaion("EMPLOYEE_DELETED");
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
