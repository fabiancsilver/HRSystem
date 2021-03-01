using HRSystem.Application.Common;
using MediatR;
using System.Collections.Generic;

namespace HRSystem.Application.Features.Shifts.Queries.GetShifts
{
    public class GetShiftsQuery : IRequest<IEnumerable<GetShiftsVm>>
    {
        public QueryParameters queryParameters { get; set; }
    }
}
