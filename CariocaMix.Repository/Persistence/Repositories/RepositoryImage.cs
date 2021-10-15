using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Repository.Persistence.Repositories.Base;

namespace CariocaMix.Repository.Persistence.Repositories
{
    public class RepositoryImage : RepositoryBase<Image, long>, IRepositoryImage
    {
        public RepositoryImage(Context context) : base(context) { }
    }
}
