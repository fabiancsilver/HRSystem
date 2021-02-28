using MediatR;

namespace HRSystem.Application.Features.Colors.Commands.UpdateColor
{
    public class UpdateColorCommand : IRequest<UpdateColorCommandResponse>
    {
        public int ColorID { get; set; }
        public string Name { get; set; }
    }
}
