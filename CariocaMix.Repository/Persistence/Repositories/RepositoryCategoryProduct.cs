using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Repository.Persistence.Repositories.Base;

namespace CariocaMix.Repository.Persistence.Repositories
{
    public class RepositoryCategoryProduct : RepositoryBase<CategoryProduct, long>, IRepositoryCategoryProduct
    {
        public RepositoryCategoryProduct(Context context) : base(context) { }
    }
}
