using HRSystem.Domain.HR;
using System.Threading.Tasks;

namespace HRSystem.Application.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task UpdatePhoto(int employeeID, string pathPhoto);
    }   
    
}
