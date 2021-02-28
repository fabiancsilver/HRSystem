using MediatR;

namespace HRSystem.Application.Features.EmailTypes.Commands.CreateEmailType
{
    public class CreateEmailTypeCommand : IRequest<CreateEmailTypeCommandResponse>
    {
        public string Name { get; set; }
    }
}
