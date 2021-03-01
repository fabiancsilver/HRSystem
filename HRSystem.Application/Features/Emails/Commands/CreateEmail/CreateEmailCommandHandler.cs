using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Emails.Commands.CreateEmail
{
    public class CreateEmailCommandHandler : IRequestHandler<CreateEmailCommand, CreateEmailCommandResponse>
    {
        private readonly IHRAsyncRepository<Email> _emailTypeRepository;
        private readonly IMapper _mapper;

        public CreateEmailCommandHandler(IMapper mapper, IHRAsyncRepository<Email> emailTypeRepository)
        {
            _mapper = mapper;
            _emailTypeRepository = emailTypeRepository;
        }

        public async Task<CreateEmailCommandResponse> Handle(CreateEmailCommand request,
                                                               CancellationToken cancellationToken)
        {
            var response = new CreateEmailCommandResponse();

            var validator = new CreateEmailCommandValidator();
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
                var emailType = _mapper.Map<Email>(request);
                _emailTypeRepository.Create(emailType);
                await _emailTypeRepository.SaveChanges();

                response.Email = _mapper.Map<CreateEmailDto>(emailType);
            }

            return response;
        }
    }
}
