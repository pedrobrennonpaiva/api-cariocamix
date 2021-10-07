using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Repository.Persistence.Repositories.Base;

namespace CariocaMix.Repository.Persistence.Repositories
{
    public class RepositoryCategory : RepositoryBase<Category, long>, IRepositoryCategory
    {
        public RepositoryCategory(Context context) : base(context) { }
    }
}
