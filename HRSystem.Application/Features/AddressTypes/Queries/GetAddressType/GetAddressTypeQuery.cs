using MediatR;
using System;

namespace HRSystem.Application.Features.AddressTypes.Queries.GetAddressType
{
    public class GetAddressTypeQuery : IRequest<GetAddressTypeVm>
    {
        public int AddressTypeID { get; set; }
    }
}
