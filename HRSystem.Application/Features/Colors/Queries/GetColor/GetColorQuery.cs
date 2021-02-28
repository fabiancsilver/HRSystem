using MediatR;
using System;

namespace HRSystem.Application.Features.Colors.Queries.GetColor
{
    public class GetColorQuery : IRequest<GetColorVm>
    {
        public int ColorID { get; set; }
    }
}
