using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, UpdateAddressCommandResponse>
    {
        private readonly IHRAsyncRepository<Address> _addressRepository;
        private readonly IMapper _mapper;

        public UpdateAddressCommandHandler(IMapper mapper, IHRAsyncRepository<Address> addressRepository)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public async Task<UpdateAddressCommandResponse> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateAddressCommandResponse();

            var validator = new UpdateAddressCommandValidator();
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
                var address = _mapper.Map<Address>(request);
                _addressRepository.Update(address.AddressID, address);
                await _addressRepository.SaveChanges();

                response.Address = _mapper.Map<UpdateAddressDto>(address);
            }

            return response;
        }
    }
}
