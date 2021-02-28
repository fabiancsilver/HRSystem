using MediatR;

namespace HRSystem.Application.Features.Statuses.Commands.CreateStatus
{
    public class CreateStatusCommand : IRequest<CreateStatusCommandResponse>
    {
        public string Name { get; set; }
    }
}
