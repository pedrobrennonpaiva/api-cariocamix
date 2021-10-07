using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Repository.Persistence.Repositories.Base;

namespace CariocaMix.Repository.Persistence.Repositories
{
    public class RepositoryDeliveryTax : RepositoryBase<DeliveryTax, long>, IRepositoryDeliveryTax
    {
        public RepositoryDeliveryTax(Context context) : base(context) { }
    }
}
