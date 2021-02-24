using HRSystem.Domain.HR;
using System.Threading.Tasks;

namespace HRSystem.Application.Repositories
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        Task<Address> GetByEmployee(int id);
    }
}
