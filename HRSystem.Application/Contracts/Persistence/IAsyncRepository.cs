using HRSystem.Application.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRSystem.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T>
    {
        Task<IEnumerable<T>> GetAll(QueryParameters queryParameters);

        Task<T> GetById(int id);

        void Create(T entity);

        void Update(int id, T entity);

        Task Remove(int id);

        Task<int> SaveChanges();
    }
}
