using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Repository.Persistence.Repositories.Base;

namespace CariocaMix.Repository.Persistence.Repositories
{
    public class RepositoryDeliveryStatus : RepositoryBase<DeliveryStatus, long>, IRepositoryDeliveryStatus
    {
        public RepositoryDeliveryStatus(Context context) : base(context) { }
    }
}
