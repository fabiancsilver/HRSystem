using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.AddressTypes.Commands.UpdateAddressType
{
    public class UpdateAddressTypeCommandHandler : IRequestHandler<UpdateAddressTypeCommand, UpdateAddressTypeCommandResponse>
    {
        private readonly IHRAsyncRepository<AddressType> _addressTypeRepository;
        private readonly IMapper _mapper;

        public UpdateAddressTypeCommandHandler(IMapper mapper, IHRAsyncRepository<AddressType> addressTypeRepository)
        {
            _mapper = mapper;
            _addressTypeRepository = addressTypeRepository;
        }

        public async Task<UpdateAddressTypeCommandResponse> Handle(UpdateAddressTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateAddressTypeCommandResponse();

            var validator = new UpdateAddressTypeCommandValidator();
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
                _addressTypeRepository.Update(addressType.AddressTypeID, addressType);
                await _addressTypeRepository.SaveChanges();

                response.AddressType = _mapper.Map<UpdateAddressTypeDto>(addressType);
            }

            return response;
        }
    }
}
