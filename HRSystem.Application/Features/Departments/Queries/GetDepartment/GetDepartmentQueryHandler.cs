using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Departments.Queries.GetDepartment
{
    public class GetDepartmentQueryHandler : IRequestHandler<GetDepartmentQuery, GetDepartmentVm>
    {
        private readonly IHRAsyncRepository<Department> _departmentRepository;
        
        private readonly IMapper _mapper;

        public GetDepartmentQueryHandler(IMapper mapper, IHRAsyncRepository<Department> departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;            
        }

        public async Task<GetDepartmentVm> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetById(request.DepartmentID);
            var departmentVm = _mapper.Map<GetDepartmentVm>(department);            

            return departmentVm;
        }
    }
}
