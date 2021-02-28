using MediatR;

namespace HRSystem.Application.Features.Statuses.Commands.DeleteStatus
{
    public class DeleteStatusCommand : IRequest<DeleteStatusCommandResponse>
    {
        public int StatusID { get; set; }
    }
}
