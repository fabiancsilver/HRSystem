using AutoMapper;
using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Domain.HR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRSystem.Application.Features.EmailTypes.Commands.DeleteEmailType
{
    public class DeleteEmailTypeCommandHandler : IRequestHandler<DeleteEmailTypeCommand, DeleteEmailTypeCommandResponse>
    {
        private readonly IHRAsyncRepository<EmailType> _emailTypeRepository;
        private readonly IMapper _mapper;

        public DeleteEmailTypeCommandHandler(IMapper mapper, IHRAsyncRepository<EmailType> emailTypeRepository)
        {
            _mapper = mapper;
            _emailTypeRepository = emailTypeRepository;
        }

        public async Task<DeleteEmailTypeCommandResponse> Handle(DeleteEmailTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteEmailTypeCommandResponse();

            var validator = new DeleteEmailTypeCommandValidator();
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
                await _emailTypeRepository.Remove(emailType.EmailTypeID);
                await _emailTypeRepository.SaveChanges();

                response.EmailType = _mapper.Map<DeleteEmailTypeDto>(emailType);
            }

            return response;
        }
    }
}
