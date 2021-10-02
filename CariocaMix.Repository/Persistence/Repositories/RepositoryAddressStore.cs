using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Repository.Persistence.Repositories.Base;

namespace CariocaMix.Repository.Persistence.Repositories
{
    public class RepositoryAddressStore : RepositoryBase<AddressStore, long>, IRepositoryAddressStore
    {
        public RepositoryAddressStore(Context context) : base(context) { }
    }
}
