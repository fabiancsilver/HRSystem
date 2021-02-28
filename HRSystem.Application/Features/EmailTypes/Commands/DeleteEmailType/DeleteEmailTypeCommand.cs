using MediatR;

namespace HRSystem.Application.Features.EmailTypes.Commands.DeleteEmailType
{
    public class DeleteEmailTypeCommand : IRequest<DeleteEmailTypeCommandResponse>
    {
        public int EmailTypeID { get; set; }
    }
}
