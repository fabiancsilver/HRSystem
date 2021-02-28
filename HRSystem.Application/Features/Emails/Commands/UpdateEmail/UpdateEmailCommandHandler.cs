using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.Emails.Commands.UpdateEmail
{
    public class UpdateEmailCommandHandler : IRequestHandler<UpdateEmailCommand, UpdateEmailCommandResponse>
    {
        private readonly IHRAsyncRepository<Email> _emailRepository;
        private readonly IMapper _mapper;

        public UpdateEmailCommandHandler(IMapper mapper, IHRAsyncRepository<Email> emailRepository)
        {
            _mapper = mapper;
            _emailRepository = emailRepository;
        }

        public async Task<UpdateEmailCommandResponse> Handle(UpdateEmailCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateEmailCommandResponse();

            var validator = new UpdateEmailCommandValidator();
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
                var email = _mapper.Map<Email>(request);
                _emailRepository.Update(email.EmailID, email);
                await _emailRepository.SaveChanges();

                response.Email = _mapper.Map<UpdateEmailDto>(email);
            }

            return response;
        }
    }
}
