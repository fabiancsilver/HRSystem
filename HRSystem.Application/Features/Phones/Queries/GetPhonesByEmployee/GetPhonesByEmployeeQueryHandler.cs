using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Application.Features.Phones.Commands.CreatePhone;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Phones.Queries.GetPhoneByEmployee
{
    public class GetPhonesByEmployeeQueryHandler : IRequestHandler<GetPhonesByEmployeeQuery, GetPhonesByEmployeeQueryResponse>
    {
        private readonly IPhoneRepository _phoneRepository;

        private readonly IMapper _mapper;

        public GetPhonesByEmployeeQueryHandler(IMapper mapper,
                                            IPhoneRepository phoneRepository)
        {
            _mapper = mapper;
            _phoneRepository = phoneRepository;
        }

        public async Task<GetPhonesByEmployeeQueryResponse> Handle(GetPhonesByEmployeeQuery request, CancellationToken cancellationToken)
        {
            var response = new GetPhonesByEmployeeQueryResponse();
            var phones = await _phoneRepository.GetAllByEmployee(request.EmployeeID);
            var phoneVm = _mapper.Map<ICollection<GetPhonesByEmployeeVm>>(phones);

            if (phones == null)
            {
                response.Success = false;
                response.Phones = null;
                return response;
            }

            response.Phones = phoneVm;
            return response;
        }
    }
}
