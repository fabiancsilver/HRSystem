using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.PhoneTypes.Commands.DeletePhoneType
{
    public class DeletePhoneTypeCommandHandler : IRequestHandler<DeletePhoneTypeCommand, DeletePhoneTypeCommandResponse>
    {
        private readonly IHRAsyncRepository<PhoneType> _phoneTypeRepository;
        private readonly IMapper _mapper;

        public DeletePhoneTypeCommandHandler(IMapper mapper, IHRAsyncRepository<PhoneType> phoneTypeRepository)
        {
            _mapper = mapper;
            _phoneTypeRepository = phoneTypeRepository;
        }

        public async Task<DeletePhoneTypeCommandResponse> Handle(DeletePhoneTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new DeletePhoneTypeCommandResponse();

            var validator = new DeletePhoneTypeCommandValidator();
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
                await _phoneTypeRepository.Remove(phoneType.PhoneTypeID);
                await _phoneTypeRepository.SaveChanges();

                response.PhoneType = _mapper.Map<DeletePhoneTypeDto>(phoneType);
            }

            return response;
        }
    }
}
