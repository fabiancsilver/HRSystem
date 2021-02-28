using HRSystem.Domain.HR;
using System.Threading.Tasks;

namespace HRSystem.Application.Contracts.Persistence.HR
{
    public interface IEmployeeRepository : IHRAsyncRepository<Employee>
    {
        Task UpdatePhoto(int employeeID, string pathPhoto);
    }

}
