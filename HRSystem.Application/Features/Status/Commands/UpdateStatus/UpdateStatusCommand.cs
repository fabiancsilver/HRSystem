using MediatR;

namespace HRSystem.Application.Features.Statuses.Commands.UpdateStatus
{
    public class UpdateStatusCommand : IRequest<UpdateStatusCommandResponse>
    {
        public int StatusID { get; set; }
        public string Name { get; set; }
    }
}
