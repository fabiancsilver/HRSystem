using HRSystem.Domain.HR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSystem.Application.Repositories
{
    public interface IPhoneRepository : IAsyncRepository<Phone>
    {
        Task<ICollection<Phone>> GetAllByEmployee(int employeeID);

        Task<Phone> GetByEmployee(int employeeID);
    }
}
