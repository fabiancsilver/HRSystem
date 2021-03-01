using AutoMapper;
using HRSystem.Application.Common;
using HRSystem.Application.Contracts.Persistence.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Employees.Queries.GetEmployees
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<GetEmployeesVm>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        private readonly IMapper _mapper;

        public GetEmployeesQueryHandler(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<GetEmployeesVm>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            QueryParameters queryParameters = request.queryParameters;

            var employees = await _employeeRepository.GetAll(queryParameters);
            var employeesVm = _mapper.Map<IEnumerable<GetEmployeesVm>>(employees);

            return employeesVm;
        }
    }
}
