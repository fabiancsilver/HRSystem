using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, CreateAddressCommandResponse>
    {
        private readonly IHRAsyncRepository<Address> _addressTypeRepository;
        private readonly IMapper _mapper;

        public CreateAddressCommandHandler(IMapper mapper, IHRAsyncRepository<Address> addressTypeRepository)
        {
            _mapper = mapper;
            _addressTypeRepository = addressTypeRepository;
        }

        public async Task<CreateAddressCommandResponse> Handle(CreateAddressCommand request,
                                                               CancellationToken cancellationToken)
        {
            var response = new CreateAddressCommandResponse();

            var validator = new CreateAddressCommandValidator();
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
                var addressType = _mapper.Map<Address>(request);
                _addressTypeRepository.Create(addressType);
                await _addressTypeRepository.SaveChanges();

                response.Address = _mapper.Map<CreateAddressDto>(addressType);
            }

            return response;
        }
    }
}
