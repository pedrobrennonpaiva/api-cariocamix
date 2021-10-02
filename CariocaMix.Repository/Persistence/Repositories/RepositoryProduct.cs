using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Repository.Persistence.Repositories.Base;

namespace CariocaMix.Repository.Persistence.Repositories
{
    public class RepositoryProduct : RepositoryBase<Product, long>, IRepositoryProduct
    {
        public RepositoryProduct(Context context) : base(context) { }
    }
}
