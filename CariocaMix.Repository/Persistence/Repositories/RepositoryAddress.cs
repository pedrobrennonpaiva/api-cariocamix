using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Repository.Persistence.Repositories.Base;

namespace CariocaMix.Repository.Persistence.Repositories
{
    public class RepositoryAddress : RepositoryBase<Address, long>, IRepositoryAddress
    {
        public RepositoryAddress(Context context) : base(context) { }
    }
}
