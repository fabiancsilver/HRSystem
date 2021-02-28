using MediatR;
using System;

namespace HRSystem.Application.Features.Positions.Queries.GetPosition
{
    public class GetPositionQuery : IRequest<GetPositionVm>
    {
        public int PositionID { get; set; }
    }
}
