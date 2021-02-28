using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.EmailTypes.Commands.CreateEmailType
{
    public class CreateEmailTypeCommandHandler : IRequestHandler<CreateEmailTypeCommand, CreateEmailTypeCommandResponse>
    {
        private readonly IHRAsyncRepository<EmailType> _emailTypeRepository;
        private readonly IMapper _mapper;

        public CreateEmailTypeCommandHandler(IMapper mapper, IHRAsyncRepository<EmailType> emailTypeRepository)
        {
            _mapper = mapper;
            _emailTypeRepository = emailTypeRepository;
        }

        public async Task<CreateEmailTypeCommandResponse> Handle(CreateEmailTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateEmailTypeCommandResponse();

            var validator = new CreateEmailTypeCommandValidator();
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
                var emailType = _mapper.Map<EmailType>(request);
                _emailTypeRepository.Create(emailType);
                await _emailTypeRepository.SaveChanges();

                response.EmailType = _mapper.Map<CreateEmailTypeDto>(emailType);
            }

            return response;
        }
    }
}
