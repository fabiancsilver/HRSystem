using HRSystem.Application.Common;
using HRSystem.Application.Features.Colors.Queries.GetColor;
using MediatR;
using System;
using System.Collections.Generic;

namespace HRSystem.Application.Features.Colors.Queries.GetColors
{
    public class GetColorsQuery : IRequest<IEnumerable<GetColorsVm>>
    {
        public QueryParameters queryParameters { get; set; }
    }
}
