using MediatR;

namespace HRSystem.Application.Features.PhoneTypes.Queries.GetPhoneType
{
    public class GetPhoneTypeQuery : IRequest<GetPhoneTypeVm>
    {
        public int PhoneTypeID { get; set; }
    }
}
