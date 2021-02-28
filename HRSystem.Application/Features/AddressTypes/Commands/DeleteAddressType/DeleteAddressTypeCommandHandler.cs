using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.AddressTypes.Commands.DeleteAddressType
{
    public class DeleteAddressTypeCommandHandler : IRequestHandler<DeleteAddressTypeCommand, DeleteAddressTypeCommandResponse>
    {
        private readonly IHRAsyncRepository<AddressType> _addressTypeRepository;
        private readonly IMapper _mapper;

        public DeleteAddressTypeCommandHandler(IMapper mapper, IHRAsyncRepository<AddressType> addressTypeRepository)
        {
            _mapper = mapper;
            _addressTypeRepository = addressTypeRepository;
        }

        public async Task<DeleteAddressTypeCommandResponse> Handle(DeleteAddressTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteAddressTypeCommandResponse();

            var validator = new DeleteAddressTypeCommandValidator();
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
                await _addressTypeRepository.Remove(addressType.AddressTypeID);
                await _addressTypeRepository.SaveChanges();

                response.AddressType = _mapper.Map<DeleteAddressTypeDto>(addressType);
            }

            return response;
        }
    }
}
