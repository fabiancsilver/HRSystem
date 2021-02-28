using HRSystem.Domain.HR;
using System.Threading.Tasks;

namespace HRSystem.Application.Contracts.Persistence.HR
{
    public interface IAddressRepository : IHRAsyncRepository<Address>
    {
        Task<Address> GetByEmployee(int id);
    }
}
