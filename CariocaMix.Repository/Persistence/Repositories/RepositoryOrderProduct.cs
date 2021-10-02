using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Repository.Persistence.Repositories.Base;

namespace CariocaMix.Repository.Persistence.Repositories
{
    public class RepositoryOrderProduct : RepositoryBase<OrderProduct, long>, IRepositoryOrderProduct
    {
        public RepositoryOrderProduct(Context context) : base(context) { }
    }
}
