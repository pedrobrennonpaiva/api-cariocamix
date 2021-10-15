using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Repository.Persistence.Repositories.Base;

namespace CariocaMix.Repository.Persistence.Repositories
{
    public class RepositoryDeliveryRemoveArea : RepositoryBase<DeliveryRemoveArea, long>, IRepositoryDeliveryRemoveArea
    {
        public RepositoryDeliveryRemoveArea(Context context) : base(context) { }
    }
}
