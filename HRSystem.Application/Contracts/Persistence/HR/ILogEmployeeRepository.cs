using HRSystem.Domain.HR;
using System.Threading.Tasks;

namespace HRSystem.Application.Contracts.Persistence.HR
{
    public interface ILogEmployeeRepository : IHRAsyncRepository<LogEmployee>
    {
        Task<int> Log(Employee employee);
    }
}
