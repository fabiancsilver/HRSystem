using MediatR;

namespace HRSystem.Application.Features.Colors.Commands.DeleteColor
{
    public class DeleteColorCommand : IRequest<DeleteColorCommandResponse>
    {
        public int ColorID { get; set; }
    }
}
