using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.EmailTypes.Commands.UpdateEmailType
{
    public class UpdateEmailTypeCommandHandler : IRequestHandler<UpdateEmailTypeCommand, UpdateEmailTypeCommandResponse>
    {
        private readonly IHRAsyncRepository<EmailType> _emailTypeRepository;
        private readonly IMapper _mapper;

        public UpdateEmailTypeCommandHandler(IMapper mapper, IHRAsyncRepository<EmailType> emailTypeRepository)
        {
            _mapper = mapper;
            _emailTypeRepository = emailTypeRepository;
        }

        public async Task<UpdateEmailTypeCommandResponse> Handle(UpdateEmailTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateEmailTypeCommandResponse();

            var validator = new UpdateEmailTypeCommandValidator();
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
                _emailTypeRepository.Update(emailType.EmailTypeID, emailType);
                await _emailTypeRepository.SaveChanges();

                response.EmailType = _mapper.Map<UpdateEmailTypeDto>(emailType);
            }

            return response;
        }
    }
}
