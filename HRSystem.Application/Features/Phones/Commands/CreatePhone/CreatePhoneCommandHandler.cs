using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Phones.Commands.CreatePhone
{
    public class CreatePhoneCommandHandler : IRequestHandler<CreatePhoneCommand, CreatePhoneCommandResponse>
    {
        private readonly IHRAsyncRepository<Phone> _phoneTypeRepository;
        private readonly IMapper _mapper;

        public CreatePhoneCommandHandler(IMapper mapper, IHRAsyncRepository<Phone> phoneTypeRepository)
        {
            _mapper = mapper;
            _phoneTypeRepository = phoneTypeRepository;
        }

        public async Task<CreatePhoneCommandResponse> Handle(CreatePhoneCommand request, 
                                                               CancellationToken cancellationToken)
        {
            var response = new CreatePhoneCommandResponse();

            var validator = new CreatePhoneCommandValidator();
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
                var phoneType = _mapper.Map<Phone>(request);
                _phoneTypeRepository.Create(phoneType);
                await _phoneTypeRepository.SaveChanges();

                response.Phone = _mapper.Map<CreatePhoneDto>(phoneType);
            }

            return response;
        }
    }
}
