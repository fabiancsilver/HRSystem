using MediatR;

namespace HRSystem.Application.Features.Positions.Queries.GetPosition
{
    public class GetPositionQuery : IRequest<GetPositionVm>
    {
        public int PositionID { get; set; }
    }
}
