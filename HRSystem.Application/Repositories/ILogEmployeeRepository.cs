using HRSystem.Domain.HR;
using System.Threading.Tasks;

namespace HRSystem.Application.Repositories
{
    public interface ILogEmployeeRepository : IAsyncRepository<LogEmployee>
    {        
        Task<int> Log(Employee employee);
    }
}
