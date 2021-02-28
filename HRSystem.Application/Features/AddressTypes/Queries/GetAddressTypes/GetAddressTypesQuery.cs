using HRSystem.Application.Common;
using MediatR;
using System.Collections.Generic;

namespace HRSystem.Application.Features.AddressTypes.Queries.GetAddressTypes
{
    public class GetAddressTypesQuery : IRequest<IEnumerable<GetAddressTypesVm>>
    {
        public QueryParameters queryParameters { get; set; }
    }
}
