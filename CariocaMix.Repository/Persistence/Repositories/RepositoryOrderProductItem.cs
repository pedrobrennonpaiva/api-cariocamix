using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Repository.Persistence.Repositories.Base;

namespace CariocaMix.Repository.Persistence.Repositories
{
    public class RepositoryOrderProductItem : RepositoryBase<OrderProductItem, long>, IRepositoryOrderProductItem
    {
        public RepositoryOrderProductItem(Context context) : base(context) { }
    }
}
