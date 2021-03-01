using HRSystem.Application.Common;
using MediatR;
using System.Collections.Generic;

namespace HRSystem.Application.Features.Colors.Queries.GetColors
{
    public class GetColorsQuery : IRequest<IEnumerable<GetColorsVm>>
    {
        public QueryParameters queryParameters { get; set; }
    }
}
