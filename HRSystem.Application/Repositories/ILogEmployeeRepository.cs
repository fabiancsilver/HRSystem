using HRSystem.Domain.HR;
using System.Threading.Tasks;

namespace HRSystem.Application.Repositories
{
    public interface ILogEmployeeRepository : IBaseRepository<LogEmployee>
    {        
        Task<int> Log(Employee employee);
    }
}
