using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.PhoneTypes.Commands.UpdatePhoneType
{
    public class UpdatePhoneTypeCommandHandler : IRequestHandler<UpdatePhoneTypeCommand, UpdatePhoneTypeCommandResponse>
    {
        private readonly IHRAsyncRepository<PhoneType> _phoneTypeRepository;
        private readonly IMapper _mapper;

        public UpdatePhoneTypeCommandHandler(IMapper mapper, IHRAsyncRepository<PhoneType> phoneTypeRepository)
        {
            _mapper = mapper;
            _phoneTypeRepository = phoneTypeRepository;
        }

        public async Task<UpdatePhoneTypeCommandResponse> Handle(UpdatePhoneTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdatePhoneTypeCommandResponse();

            var validator = new UpdatePhoneTypeCommandValidator();
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
                var phoneType = _mapper.Map<PhoneType>(request);
                _phoneTypeRepository.Update(phoneType.PhoneTypeID, phoneType);
                await _phoneTypeRepository.SaveChanges();

                response.PhoneType = _mapper.Map<UpdatePhoneTypeDto>(phoneType);
            }

            return response;
        }
    }
}
