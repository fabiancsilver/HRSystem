using HRSystem.Application.Common;
using HRSystem.Application.Features.Shifts.Queries.GetShift;
using MediatR;
using System;
using System.Collections.Generic;

namespace HRSystem.Application.Features.Shifts.Queries.GetShifts
{
    public class GetShiftsQuery : IRequest<IEnumerable<GetShiftsVm>>
    {
        public QueryParameters queryParameters { get; set; }
    }
}
