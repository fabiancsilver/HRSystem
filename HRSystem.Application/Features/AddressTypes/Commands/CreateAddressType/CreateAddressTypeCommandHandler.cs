using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.AddressTypes.Commands.CreateAddressType
{
    public class CreateAddressTypeCommandHandler : IRequestHandler<CreateAddressTypeCommand, CreateAddressTypeCommandResponse>
    {
        private readonly IHRAsyncRepository<AddressType> _addressTypeRepository;
        private readonly IMapper _mapper;

        public CreateAddressTypeCommandHandler(IMapper mapper, IHRAsyncRepository<AddressType> addressTypeRepository)
        {
            _mapper = mapper;
            _addressTypeRepository = addressTypeRepository;
        }

        public async Task<CreateAddressTypeCommandResponse> Handle(CreateAddressTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateAddressTypeCommandResponse();

            var validator = new CreateAddressTypeCommandValidator();
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
                var addressType = _mapper.Map<AddressType>(request);
                _addressTypeRepository.Create(addressType);
                await _addressTypeRepository.SaveChanges();

                response.AddressType = _mapper.Map<CreateAddressTypeDto>(addressType);
            }

            return response;
        }
    }
}
