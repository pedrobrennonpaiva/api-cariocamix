using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Repository.Persistence.Repositories.Base;

namespace CariocaMix.Repository.Persistence.Repositories
{
    public class RepositoryStoreDayHour : RepositoryBase<StoreDayHour, long>, IRepositoryStoreDayHour
    {
        public RepositoryStoreDayHour(Context context) : base(context) { }
    }
}
