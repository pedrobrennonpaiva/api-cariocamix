using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Repository.Persistence.Repositories.Base;

namespace CariocaMix.Repository.Persistence.Repositories
{
    public class RepositoryOrder : RepositoryBase<Order, long>, IRepositoryOrder
    {
        public RepositoryOrder(Context context) : base(context) { }
    }
}
