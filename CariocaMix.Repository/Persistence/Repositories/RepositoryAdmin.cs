using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Repository.Persistence.Repositories.Base;

namespace CariocaMix.Repository.Persistence.Repositories
{
    public class RepositoryAdmin : RepositoryBase<Admin, long>, IRepositoryAdmin
    {
        public RepositoryAdmin(Context context) : base(context) { }
    }
}
