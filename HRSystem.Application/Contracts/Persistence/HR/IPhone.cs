using HRSystem.Domain.HR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSystem.Application.Contracts.Persistence.HR
{
    public interface IPhoneRepository : IHRAsyncRepository<Phone>
    {
        Task<ICollection<Phone>> GetAllByEmployee(int employeeID);

        Task<Phone> GetByEmployee(int employeeID);
    }
}
