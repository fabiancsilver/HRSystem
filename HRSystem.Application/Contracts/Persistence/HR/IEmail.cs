using HRSystem.Domain.HR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSystem.Application.Contracts.Persistence.HR
{
    public interface IEmailRepository : IHRAsyncRepository<Email>
    {
        Task<ICollection<Email>> GetAllByEmployee(int employeeID);
    }
}
