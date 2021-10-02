using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Repository.Persistence.Repositories.Base;

namespace CariocaMix.Repository.Persistence.Repositories
{
    public class RepositoryItem : RepositoryBase<Item, long>, IRepositoryItem
    {
        public RepositoryItem(Context context) : base(context) { }
    }
}
