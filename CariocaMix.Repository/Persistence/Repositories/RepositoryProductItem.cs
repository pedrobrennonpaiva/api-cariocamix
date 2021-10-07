using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Repository.Persistence.Repositories.Base;

namespace CariocaMix.Repository.Persistence.Repositories
{
    public class RepositoryProductItem : RepositoryBase<ProductItem, long>, IRepositoryProductItem
    {
        public RepositoryProductItem(Context context) : base(context) { }
    }
}
