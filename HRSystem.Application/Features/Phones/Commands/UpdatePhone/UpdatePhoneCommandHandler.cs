using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Phones.Commands.UpdatePhone
{
    public class UpdatePhoneCommandHandler : IRequestHandler<UpdatePhoneCommand, UpdatePhoneCommandResponse>
    {
        private readonly IHRAsyncRepository<Phone> _phoneRepository;
        private readonly IMapper _mapper;

        public UpdatePhoneCommandHandler(IMapper mapper, IHRAsyncRepository<Phone> phoneRepository)
        {
            _mapper = mapper;
            _phoneRepository = phoneRepository;
        }

        public async Task<UpdatePhoneCommandResponse> Handle(UpdatePhoneCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdatePhoneCommandResponse();

            var validator = new UpdatePhoneCommandValidator();
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
                var phone = _mapper.Map<Phone>(request);
                _phoneRepository.Update(phone.PhoneID, phone);
                await _phoneRepository.SaveChanges();

                response.Phone = _mapper.Map<UpdatePhoneDto>(phone);
            }

            return response;
        }
    }
}
