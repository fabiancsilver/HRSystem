using HRSystem.Domain.HR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSystem.Application.Repositories
{
    public interface IEmailRepository : IAsyncRepository<Email>
    {
        Task<ICollection<Email>> GetAllByEmployee(int employeeID);
    }
}
