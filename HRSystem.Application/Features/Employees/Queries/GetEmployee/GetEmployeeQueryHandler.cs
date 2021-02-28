using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Employees.Queries.GetEmployee
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, GetEmployeeVm>
    {
        private readonly IHRAsyncRepository<Employee> _employeeRepository;

        private readonly IMapper _mapper;

        public GetEmployeeQueryHandler(IMapper mapper, IHRAsyncRepository<Employee> employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task<GetEmployeeVm> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetById(request.EmployeeID);
            var employeeVm = _mapper.Map<GetEmployeeVm>(employee);

            return employeeVm;
        }
    }
}
