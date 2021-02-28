using MediatR;

namespace HRSystem.Application.Features.Colors.Commands.CreateColor
{
    public class CreateColorCommand : IRequest<CreateColorCommandResponse>
    {
        public string Name { get; set; }
    }
}
