using HRSystem.Application.Contracts.Persistence.HR;
using HRSystem.Persistence.HR;


namespace HRSystem.Persistence.Repositories.HR
{
    public class HRRepository<T> : BaseRepository<T>, IHRAsyncRepository<T> where T : class
    {
        public readonly HRContext _hrDbContext;

        public HRRepository(HRContext hrDbContext) : base(hrDbContext)
        {
            _hrDbContext = hrDbContext;
        }
    }
}
