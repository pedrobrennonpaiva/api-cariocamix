using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Repository.Persistence.Repositories.Base;

namespace CariocaMix.Repository.Persistence.Repositories
{
    public class RepositoryStore : RepositoryBase<Store, long>, IRepositoryStore
    {
        public RepositoryStore(Context context) : base(context) { }
    }
}
